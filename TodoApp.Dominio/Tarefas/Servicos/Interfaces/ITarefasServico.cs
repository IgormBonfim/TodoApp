using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;

namespace TodoApp.Dominio.Tarefas.Servicos.Interfaces
{
    public interface ITarefasServico
    {
        Tarefa Instanciar(string nome, string detalhes);
        Tarefa Recuperar(string id);
        void Inserir(Tarefa tarefa);
    }
}
