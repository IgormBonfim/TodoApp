using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Servicos.Comandos;

namespace TodoApp.Dominio.Tarefas.Servicos.Interfaces
{
    public interface ITarefasServico
    {
        Tarefa Validar(string id);
        Tarefa Instanciar(string nome, string detalhes);
        Tarefa Atualizar(TarefaAtualizarComando comando);
        void Inserir(Tarefa tarefa);
        void Excluir(string id);
    }
}
