using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Dominio.Tarefas.Servicos.Interfaces;

namespace TodoApp.Dominio.Tarefas.Servicos
{
    public class TarefasServico : ITarefasServico
    {
        private readonly ITarefasRepositorio _tarefasRepositorio;

        public TarefasServico(ITarefasRepositorio tarefasRepositorio)
        {
            this._tarefasRepositorio = tarefasRepositorio;
        }

        public void Inserir(Tarefa tarefa)
        {
            _tarefasRepositorio.Adicionar(tarefa);
        }

        public Tarefa Instanciar(string nome, string detalhes)
        {
            return new Tarefa(nome, detalhes);
        }

        public Tarefa Recuperar(string id)
        {
            Tarefa tarefa = _tarefasRepositorio.Recuperar(id);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            return tarefa;
        }
    }
}
