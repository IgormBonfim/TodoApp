using TodoApp.Dominio.Genericos.Exceptions;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Enumeradores;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Dominio.Tarefas.Servicos.Comandos;
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

        public Tarefa Atualizar(TarefaAtualizarComando comando)
        {
            Tarefa tarefa = Validar(comando.Id);

            if (tarefa.Status == StatusTarefaEnum.Concluida)
                throw new BadRequestException("Não é possível editar uma Tarefa concluída.");

            if (comando.Nome != null)
                tarefa.SetNome(comando.Nome);

            if (comando.Detalhes != null)
                tarefa.SetDetalhes(comando.Detalhes);

            if (comando.Status != null)
                tarefa.SetStatus(comando.Status.Value);

            tarefa.SetDataAtualizacao();

            if(comando.Status == StatusTarefaEnum.Concluida)
            {
                DateTime data = DateTime.Now;
                tarefa.SetDataConclusao(data);
            }

            _tarefasRepositorio.Atualizar(comando.Id, tarefa);

            return tarefa;
        }

        public void Inserir(Tarefa tarefa)
        {
            _tarefasRepositorio.Adicionar(tarefa);
        }

        public Tarefa Instanciar(string nome, string detalhes)
        {
            return new Tarefa(nome, detalhes, StatusTarefaEnum.Aguardando);
        }

        public Tarefa Validar(string id)
        {
            Tarefa tarefa = _tarefasRepositorio.Recuperar(id);

            if (tarefa == null)
                throw new NotFoundException("Tarefa não encontrada.");

            return tarefa;
        }

        public void Excluir(string id)
        {
            Tarefa tarefa = Validar(id);

            _tarefasRepositorio.Excluir(id);
        }
    }
}
