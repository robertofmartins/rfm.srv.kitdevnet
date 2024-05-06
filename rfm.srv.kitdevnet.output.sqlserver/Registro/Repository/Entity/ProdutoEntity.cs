namespace rfm.srv.kitdevnet.output.sqlserver.dapper.Registro.Repository.Entity
{
    internal class ProdutoEntity
    {
        internal int Id { get; set; }

        internal string Descricao { get; set; }

        internal int Quantidade { get; set; }

        internal decimal PrecoUnitario { get; set; }

        internal bool Ativo { get; set; }

        internal DateTime DataCriacao { get; set; }
    }
}
