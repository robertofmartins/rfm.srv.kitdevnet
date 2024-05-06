using rfm.srv.kitdevnet.domain.models.Produto;
using rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Entity;

namespace rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Mapper
{
    internal class ProdutoEntityMapper
    {
        internal ProdutoModel toModel(ProdutoEntity entity)
        {
            ProdutoModel? model = null;
            if (entity != null)
            {
                model = new ProdutoModel(
                    entity.Id,
                    entity.Descricao,
                    entity.Quantidade,
                    entity.PrecoUnitario,
                    entity.Ativo,
                    entity.DataCriacao);
            }

            return model;
        }
    }
}
