namespace rfm.srv.kitdevnet.domain.models.Comuns
{
    public class ResultadoPaginado<T>
    {
        public int Pagina { get; set; }

        public int Tamanho { get; set; }

        public long TotalRegistros { get; set; }

        public int TotalPaginas => (int)Math.Ceiling(decimal.Divide(TotalRegistros, Tamanho));

        public List<T> Itens { get; set; }
    }
}
