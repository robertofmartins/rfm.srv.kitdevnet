using rfm.srv.kitdevnet.domain.models.Registro;

namespace rfm.srv.kitdevnet.domain.interfaces.output
{
    public interface IRegistroPort
    {
        Task<Guid> Criar(RegistroCriarModel model);

        Task<RegistroModel> Obter(Guid id);

        Task<List<RegistroModel>> ListarTodos();

        Task<Guid> Atualizar(Guid id, RegistroCriarModel model);

        Task Excluir(Guid id);
    }
}
