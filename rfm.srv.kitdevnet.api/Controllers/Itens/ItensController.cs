using Microsoft.AspNetCore.Mvc;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.models.Comuns;
using rfm.srv.kitdevnet.domain.models.Item;

namespace rfm.srv.kitdevnet.api.Controllers.items
{
    [ApiController]
    [Route("v1/itens")]
    public class ItensController(IItemUserCase itemUserCase) : ControllerBase
    {
        private readonly IItemUserCase _itemUserCase = itemUserCase;

        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] ItemCriarModel model)
        {
            var id = await _itemUserCase.Criar(model);
            return Created(string.Empty, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> Obter([FromRoute] int id)
        {
            var item = await _itemUserCase.Obter(id);
            return Ok(item);
        }

        [HttpGet()]
        public async Task<ActionResult<ResultadoPaginado<ItemModel>>> ListarPaginado([FromQuery] BaseFiltroRequest filtro)
        {
            var filtroDomain = new BaseFiltro()
            {
                Pagina = filtro.Pagina,
                Tamanho = filtro.Tamanho,
            };

            var item = await _itemUserCase.ListarPaginado(filtroDomain);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemModel>> Excluir([FromRoute] int id)
        {
            await _itemUserCase.Excluir(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Atualizar([FromRoute] int id, [FromBody] ItemCriarModel model)
        {
            await _itemUserCase.Atualizar(id, model);
            return Created(string.Empty, id);
        }
    }
}
