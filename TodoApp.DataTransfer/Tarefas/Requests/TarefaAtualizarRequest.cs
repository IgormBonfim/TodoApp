using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoApp.DataTransfer.Tarefas.Requests
{
    public class TarefaAtualizarRequest
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Detalhes { get; set; }
        public int? Status { get; set; }
    }
}
