using rfm.srv.kitdevnet.domain.interfaces.output;
using rfm.srv.kitdevnet.domain.models.Registro;
using rfm.srv.kitdevnet.output.mongo.commons;
using rfm.srv.kitdevnet.output.mongo.Registro.Repository;

namespace rfm.srv.kitdevnet.output.mongo.Registro
{
    public class RegistroPersistence(KitDevNetDatabaseSettings kitDevNetDatabaseSettings) : IRegistroPort
    {

        private RegistroMDRepository _registroMDRepository = new(kitDevNetDatabaseSettings);


        public async Task<Guid> Atualizar(Guid id, RegistroCriarModel model)
        {
            id = await _registroMDRepository.Atualizar(id, model);
            return id;
        }

        public async Task<Guid> Criar(RegistroCriarModel model)
        {
            var id = await _registroMDRepository.Criar(model);
            return id;
        }

        public async Task Excluir(Guid id)
        {
            await _registroMDRepository.Excluir(id);
        }

        public async Task<List<RegistroModel>> ListarTodos()
        {
            var lst = await _registroMDRepository.ListarTodos();
            return lst;
        }

        public async Task<RegistroModel> Obter(Guid id)
        {
            var model = await _registroMDRepository.Obter(id);
            return model;
        }
    }
}
