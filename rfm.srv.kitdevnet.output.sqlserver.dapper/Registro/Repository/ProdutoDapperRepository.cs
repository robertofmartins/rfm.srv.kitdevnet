using System.Data;
using Dapper;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Query;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Mapper;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Entity;
using rfm.srv.kitdevnet.domain.models.Produto;

namespace rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository
{
    internal class ProdutoDapperRepository
    {
        private readonly IDbConnection _connection;
        private readonly ProdutoEntityMapper _produtoEntityMapper;

        internal ProdutoDapperRepository(IDbConnection connection)
        {
            _connection = connection;
            _produtoEntityMapper = new ProdutoEntityMapper();
        }

        internal async Task<int> Atualizar(int id, ProdutoCriarModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("descricao", model.Descricao, DbType.String);
            parameters.Add("quantidade", model.Quantidade, DbType.Int32);
            parameters.Add("precoUnitario", model.PrecoUnitario, DbType.Decimal);
            parameters.Add("ativo", model.Ativo, DbType.Boolean);
            parameters.Add("dataCriacao", DateTime.Now, DbType.DateTime);

            await _connection.ExecuteAsync(ItemQueries.ATUALIZAR, parameters);
            return id;
        }

        internal async Task<int> Criar(ProdutoCriarModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("descricao", model.Descricao, DbType.String);
            parameters.Add("quantidade", model.Quantidade, DbType.Int32);
            parameters.Add("precoUnitario", model.PrecoUnitario, DbType.Decimal);
            parameters.Add("ativo", model.Ativo, DbType.Boolean);
            parameters.Add("dataCriacao", DateTime.Now, DbType.DateTime);

            var id = await _connection.QuerySingleAsync<int>(ItemQueries.CRIAR, parameters);
            return id;
        }

        internal async Task Excluir(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            await _connection.ExecuteAsync(ItemQueries.EXCLUIR, parameters);
        }

        internal async Task<ResultadoPaginado<ProdutoModel>> ListarPaginado(BaseFiltro filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("pagina", filtro.Pagina, DbType.Int32);
            parameters.Add("tamanho", filtro.Tamanho, DbType.Int32);

            var total = await _connection.ExecuteScalarAsync<int>(ItemQueries.COUNT, parameters);
            var ents = await _connection.QueryAsync<ProdutoEntity>(ItemQueries.LISTAR_PAGINADO, parameters);

            var lst = new List<ProdutoModel>();
            foreach (var ent in ents)
            {
                var model = _produtoEntityMapper.toModel(ent);
                lst.Add(model);
            }

            var result = new ResultadoPaginado<ProdutoModel>()
            {
                Itens = lst,
                Tamanho = filtro.Tamanho,
                Pagina = filtro.Pagina,
                TotalRegistros = total,
            };

            return result;
        }

        internal async Task<ProdutoModel> Obter(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var ent = await _connection.QueryFirstOrDefaultAsync<ProdutoEntity>(ItemQueries.OBTER, parameters);

            var model = _produtoEntityMapper.toModel(ent);
            return model;
        }
    }
}
