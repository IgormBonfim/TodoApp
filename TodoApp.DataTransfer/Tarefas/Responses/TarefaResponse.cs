using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataTransfer.Tarefas.Responses
{
    public class TarefaResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
