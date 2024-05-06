using Microsoft.AspNetCore.Mvc;
using rfm.srv.kitdevnet.domain.interfaces.input;
using rfm.srv.kitdevnet.domain.models.Item;
using rfm.srv.kitdevnet.domain.models.Registro;

namespace rfm.srv.kitdevnet.api.Controllers.Registros
{
    [ApiController]
    [Route("v1/registros")]
    public class RegistrosController(IRegistroUserCase registroUserCase) : ControllerBase
    {
        private readonly IRegistroUserCase _registroUserCase = registroUserCase;

        [HttpPost]
        public async Task<ActionResult<Guid>> Criar([FromBody] RegistroCriarModel model)
        {
            var id = await _registroUserCase.Criar(model);
            return Created(string.Empty, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroModel>> Obter([FromRoute] Guid id)
        {
            var registro = await _registroUserCase.Obter(id);
            return Ok(registro);
        }

        [HttpGet()]
        public async Task<ActionResult<List<ItemModel>>> ListarTodos()
        {
            var item = await _registroUserCase.ListarTodos();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroModel>> Excluir([FromRoute] Guid id)
        {
            await _registroUserCase.Excluir(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Atualizar([FromRoute] Guid id, [FromBody] RegistroCriarModel model)
        {
            await _registroUserCase.Atualizar(id, model);
            return Created(string.Empty, id);
        }
    }
}
