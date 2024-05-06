using rfm.srv.kitdevnet.domain.exceptions;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Produto;

namespace rfm.srv.kitdevnet.service.Produto
{
    public class ProdutoServices(IProdutoPort produtoPort) : IProdutoUserCase
    {
        public readonly IProdutoPort _produtoPort = produtoPort;

        public async Task<int> Atualizar(int id, ProdutoCriarModel model)
        {
            ValidarModel(model);
            id = await _produtoPort.Atualizar(id, model);
            return id;
        }

        public async Task<int> Criar(ProdutoCriarModel model)
        {
            ValidarModel(model);
            var id = await _produtoPort.Criar(model);
            return id;
        }

        public async Task Excluir(int id)
        {
            await _produtoPort.Excluir(id);
        }

        public async Task<ResultadoPaginado<ProdutoModel>> ListarPaginado(BaseFiltro filtro)
        {
            var lst = await _produtoPort.ListarPaginado(filtro);
            return lst;
        }

        public async Task<ProdutoModel> Obter(int id)
        {
            var model = await _produtoPort.Obter(id);
            return model;
        }

        private void ValidarModel(ProdutoCriarModel model)
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
