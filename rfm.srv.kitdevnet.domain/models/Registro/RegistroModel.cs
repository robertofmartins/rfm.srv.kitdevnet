namespace rfm.srv.kitdevnet.domain.models.Registro
{
    public record RegistroModel(Guid Id, string Descricao, int Quantidade, decimal PrecoUnitario, bool Ativo, DateTime DataCriacao);
}
