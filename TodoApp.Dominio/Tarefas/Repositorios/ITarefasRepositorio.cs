using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Genericos.Interfaces;
using TodoApp.Dominio.Tarefas.Entidades;

namespace TodoApp.Dominio.Tarefas.Repositorios
{
    public interface ITarefasRepositorio : IMongoRepositorio<Tarefa>
    {

    }
}
