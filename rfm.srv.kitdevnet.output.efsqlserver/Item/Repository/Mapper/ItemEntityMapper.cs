using rfm.srv.kitdevnet.domain.models.Item;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Entity;

namespace rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Mapper
{
    internal class ItemEntityMapper
    {
        internal async Task<ItemEntity> toEntidade(ItemCriarModel model)
        {
            var ent = new ItemEntity()
            {
                Descricao = model.Descricao,
                Quantidade = model.Quantidade,
                PrecoUnitario = model.PrecoUnitario,
                Ativo = model.Ativo,
                DataCriacao = DateTime.Now,
            };

            return ent;
        }

        internal async Task<ItemModel> toModel(ItemEntity entity)
        {
            ItemModel? model = null;
            if (entity != null)
            {
                model = new ItemModel(
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
