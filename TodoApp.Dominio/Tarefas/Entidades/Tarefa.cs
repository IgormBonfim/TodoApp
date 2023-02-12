using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Enumeradores;

namespace TodoApp.Dominio.Tarefas.Entidades
{
    public class Tarefa
    {
        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Detalhes { get; protected set; }
        public StatusTarefaEnum Status { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }
        public DateTime? DataConclusao { get; protected set; }

        public Tarefa() { }

        public Tarefa(string nome, string detalhes, StatusTarefaEnum status)
        {
            SetId();
            SetNome(nome);
            SetDetalhes(detalhes);
            SetStatus(status);
            SetDataCadastro();
        }

        public void SetId()
        {
            string guid = Guid.NewGuid().ToString();
            Id = guid;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length <= 3)
            {
                throw new Exception("O campo nome é obrigatório");
            }
            Nome = nome;
        }

        public void SetDetalhes(string detalhes)
        {
            if (string.IsNullOrWhiteSpace(detalhes) || detalhes.Length <= 5)
            {
                throw new Exception("O campo detalhes é obrigatório");
            }
            Detalhes = detalhes;
        }

        public void SetStatus(StatusTarefaEnum status)
        {
            Status = status;
        }

        protected void SetDataCadastro()
        {
            DateTime hoje = DateTime.Now;
            DataCadastro = hoje;
        }

        public void SetDataAtualizacao()
        {
            DataAtualizacao = DateTime.Now;
        }

        public void SetDataConclusao(DateTime? data)
        {
            DataConclusao = data;
        }
    }
}