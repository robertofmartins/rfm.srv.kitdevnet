using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;

namespace rfm.srv.kitdevnet.domain.interfaces.input
{
    public interface IItemUserCase
    {
        Task<int> Criar(ItemCriarModel model);

        Task<ItemModel> Obter(int id);

        Task<ResultadoPaginado<ItemModel>> ListarPaginado(BaseFiltro filtro);

        Task<int> Atualizar(int id, ItemCriarModel model);

        Task Excluir(int id);
    }
}
