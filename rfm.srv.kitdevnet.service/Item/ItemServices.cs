using rfm.srv.kitdevnet.domain.exceptions;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;

namespace rfm.srv.kitdevnet.service.Item
{
    public class ItemServices(IItemPort itemPort) : IItemUserCase
    {
        private readonly IItemPort _itemPort = itemPort;

        public async Task<int> Atualizar(int id, ItemCriarModel model)
        {
            ValidarModel(model);
            id = await _itemPort.Atualizar(id, model);
            return id;
        }

        public async Task<int> Criar(ItemCriarModel model)
        {
            ValidarModel(model);
            var id = await _itemPort.Criar(model);
            return id;
        }

        public async Task Excluir(int id)
        {
            await _itemPort.Excluir(id);
        }

        public async Task<ResultadoPaginado<ItemModel>> ListarPaginado(BaseFiltro filtro)
        {
            var lst = await _itemPort.ListarPaginado(filtro);
            return lst;
        }

        public async Task<ItemModel> Obter(int id)
        {
            var model = await _itemPort.Obter(id);
            return model;
        }

        private void ValidarModel(ItemCriarModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (String.IsNullOrWhiteSpace(model.Descricao))
            {
                throw new BusinessException("0001", "Campo Descricao é obrigatório.");
            }

            if (model.Quantidade < 0)
            {
                throw new BusinessException("0001", "Campo Quantidade deve ser maior do zero.");
            }
        }
    }
}
