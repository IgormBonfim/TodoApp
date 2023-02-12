using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Enumeradores;

namespace TodoApp.Dominio.Tarefas.Servicos.Comandos
{
    public class TarefaAtualizarComando
    {
        public string Id { get; set; }
        public string? Nome { get; set; }
        public string? Detalhes { get; set; }
        public StatusTarefaEnum? Status { get; set; }
    }
}
