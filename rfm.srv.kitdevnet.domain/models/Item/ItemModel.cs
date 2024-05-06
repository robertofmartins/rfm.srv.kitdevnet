namespace rfm.srv.kitdevnet.domain.models.Item
{
    public record ItemModel(int Id, string Descricao, int Quantidade, decimal PrecoUnitario, bool Ativo, DateTime DataCriacao);
}
