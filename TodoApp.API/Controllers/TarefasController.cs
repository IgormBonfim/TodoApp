using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Aplicacao.Tarefas.Servicos.Interfaces;
using TodoApp.DataTransfer.Tarefas.Requests;
using TodoApp.DataTransfer.Tarefas.Responses;

namespace TodoApp.API.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasAppServico _tarefasAppServico;

        public TarefasController(ITarefasAppServico tarefasAppServico) 
        {
            this._tarefasAppServico = tarefasAppServico;
        }

        [HttpGet]
        public IActionResult Listar() 
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<TarefaResponse> Inserir([FromBody] TarefaInserirRequest request)
        {
            var response = _tarefasAppServico.Inserir(request);
            return Ok(response);
        }
    }
}
