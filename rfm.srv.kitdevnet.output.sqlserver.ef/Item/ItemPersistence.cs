using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;
using rfm.srv.kitdevnet.output.sqlserver.ef.commons;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository;

namespace rfm.srv.kitdevnet.output.sqlserver.ef.Item
{
    public class ItemPersistence(EFSqlServerContext context) : IItemPort
    {
        private readonly ItemEFRepository _itemRepo = new(context);

        public async Task<int> Atualizar(int id, ItemCriarModel model)
        {
            id = await _itemRepo.Atualizar(id, model);
            return id;
        }

        public async Task<int> Criar(ItemCriarModel model)
        {
            var id = await _itemRepo.Criar(model);
            return id;
        }

        public async Task Excluir(int id)
        {
            await _itemRepo.Excluir(id);
        }

        public async Task<ResultadoPaginado<ItemModel>> ListarPaginado(BaseFiltro filtro)
        {
            var result = await _itemRepo.ListarPaginado(filtro);
            return result;
        }

        public async Task<ItemModel> Obter(int id)
        {
            var model = await _itemRepo.Obter(id);
            return model;
        }
    }
}
