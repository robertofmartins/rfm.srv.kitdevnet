namespace rfm.srv.kitdevnet.domain.models.Produto
{
    public record ProdutoModel(int Id, string Descricao, int Quantidade, decimal PrecoUnitario, bool Ativo, DateTime DataCriacao);
}
