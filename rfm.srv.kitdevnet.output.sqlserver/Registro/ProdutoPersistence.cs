using System.Data;
using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Produto;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository;

namespace rfm.srv.kitdevnet.output.sqlserver.dapper.Registro
{
    public class ProdutoPersistence(IDbConnection connection) : IProdutoPort
    {
        private readonly ProdutoDapperRepository _produtoRepo = new(connection);

        public async Task<int> Atualizar(int id, ProdutoCriarModel model)
        {
            id = await _produtoRepo.Atualizar(id, model);
            return id;
        }

        public async Task<int> Criar(ProdutoCriarModel model)
        {
            var id = await _produtoRepo.Criar(model);
            return id;
        }

        public async Task Excluir(int id)
        {
            await _produtoRepo.Excluir(id);
        }

        public async Task<ResultadoPaginado<ProdutoModel>> ListarPaginado(BaseFiltro filtro)
        {
            var lst = await _produtoRepo.ListarPaginado(filtro);
            return lst;
        }

        public async Task<ProdutoModel> Obter(int id)
        {
            var model = await _produtoRepo.Obter(id);
            return model;
        }
    }
}
