using Microsoft.AspNetCore.Mvc;

namespace rfm.srv.kitdevnet.api.Controllers
{
    public class BaseFiltroRequest
    {
        [FromQuery(Name = "page_number")]
        public int Pagina { get; set; }

        [FromQuery(Name = "page_size")]
        public int Tamanho { get; set; }
    }
}
