using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;

namespace TodoApp.Dominio.Tarefas.Repositorios
{
    public interface ITarefasRepositorio
    {
        void Adicionar(Tarefa tarefa);
        void Atualizar(string id, Tarefa tarefa);
        IList<Tarefa> Listar();
        Tarefa Recuperar(string id);
        void Excluir(string id);
    }
}
