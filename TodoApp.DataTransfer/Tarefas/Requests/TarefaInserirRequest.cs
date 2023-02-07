using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataTransfer.Tarefas.Requests
{
    public class TarefaInserirRequest
    {
        public string Nome { get; set; }
        public string Detalhes { get; set; }
    }
}
