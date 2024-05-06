namespace rfm.srv.kitdevnet.domain.exceptions
{
    public class BusinessException : Exception
    {
        public string Codigo { get; set; }

        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BusinessException(string codigo, string message)
            : base(message)
        {
            this.Codigo = codigo;
        }

        public BusinessException(string codigo, string message, Exception inner)
            : base(message, inner)
        {
            this.Codigo = codigo;
        }
    }
}
