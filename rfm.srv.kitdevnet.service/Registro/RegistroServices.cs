using rfm.srv.kitdevnet.domain.exceptions;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Registro;

namespace rfm.srv.kitdevnet.service.Registro
{
    public class RegistroServices(IRegistroPort registroPort) : IRegistroUserCase
    {
        public readonly IRegistroPort _registroPort = registroPort;

        public async Task<Guid> Atualizar(Guid id, RegistroCriarModel model)
        {
            ValidarModel(model);
            id = await _registroPort.Atualizar(id, model);
            return id;
        }

        public async Task<Guid> Criar(RegistroCriarModel model)
        {
            ValidarModel(model);
            var id = await _registroPort.Criar(model);
            return id;
        }

        public async Task Excluir(Guid id)
        {
            await _registroPort.Excluir(id);
        }

        public async Task<List<RegistroModel>> ListarTodos()
        {
            var lst = await _registroPort.ListarTodos();
            return lst;
        }

        public async Task<RegistroModel> Obter(Guid id)
        {
            var model = await _registroPort.Obter(id);
            return model;
        }

        private void ValidarModel(RegistroCriarModel model)
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
