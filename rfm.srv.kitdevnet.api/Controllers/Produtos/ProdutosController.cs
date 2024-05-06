using Microsoft.AspNetCore.Mvc;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;
using rfm.srv.kitdevnet.domain.models.Produto;

namespace rfm.srv.kitdevnet.api.Controllers.registros
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutosController(IProdutoUserCase produtoUserCase) : ControllerBase
    {
        private readonly IProdutoUserCase _produtoUserCase = produtoUserCase;

        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] ProdutoCriarModel model)
        {
            var id = await _produtoUserCase.Criar(model);
            return Created(string.Empty, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> Obter([FromRoute] int id)
        {
            var registro = await _produtoUserCase.Obter(id);
            return Ok(registro);
        }

        [HttpGet()]
        public async Task<ActionResult<ResultadoPaginado<ItemModel>>> ListarPaginado([FromQuery] BaseFiltroRequest filtro)
        {
            var filtroDomain = new BaseFiltro()
            {
                Pagina = filtro.Pagina,
                Tamanho = filtro.Tamanho,
            };

            var item = await _produtoUserCase.ListarPaginado(filtroDomain);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Excluir([FromRoute] int id)
        {
            await _produtoUserCase.Excluir(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id, [FromBody] ProdutoCriarModel model)
        {
            await _produtoUserCase.Atualizar(id, model);
            return Created(string.Empty, id);
        }
    }
}
