using Amazon.Runtime.Internal;
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
        public ActionResult<IList<TarefaResponse>> Listar([FromQuery] TarefaListarRequest request)
        {
            var response = _tarefasAppServico.Listar(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<TarefaResponse> Recuperar(string id)
        {
            var response = _tarefasAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<TarefaResponse> Inserir([FromBody] TarefaInserirRequest request)
        {
            var response = _tarefasAppServico.Inserir(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<TarefaResponse> Atualizar(string id, [FromBody] TarefaAtualizarRequest request)
        {
            request.Id = id;

            var response = _tarefasAppServico.Atualizar(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(string id)
        {
            _tarefasAppServico.Excluir(id);

            return Ok();
        }
    }
}
