using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Aplicacao.Tarefas.Servicos.Interfaces;
using TodoApp.DataTransfer.Genericos.Responses;
using TodoApp.DataTransfer.Tarefas.Requests;
using TodoApp.DataTransfer.Tarefas.Responses;
using TodoApp.Dominio.Genericos.Entidades;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Dominio.Tarefas.Servicos.Comandos;
using TodoApp.Dominio.Tarefas.Servicos.Interfaces;

namespace TodoApp.Aplicacao.Tarefas.Servicos
{
    public class TarefasAppServico : ITarefasAppServico
    {
        private readonly ITarefasServico _tarefasServico;
        private readonly ITarefasRepositorio _tarefasRepositorio;
        private readonly IMapper _mapper;

        public TarefasAppServico(ITarefasServico tarefasServico, ITarefasRepositorio tarefasRepositorio, IMapper mapper)
        {
            this._tarefasServico = tarefasServico;
            this._tarefasRepositorio = tarefasRepositorio;
            this._mapper = mapper;
        }

        public TarefaResponse Atualizar(TarefaAtualizarRequest request)
        {
            TarefaAtualizarComando comando = _mapper.Map<TarefaAtualizarComando>(request);

            Tarefa tarefa = _tarefasServico.Atualizar(comando);

            return _mapper.Map<TarefaResponse>(tarefa);

        }

        public void Excluir(string id)
        {
            _tarefasServico.Excluir(id);
        }

        public TarefaResponse Inserir(TarefaInserirRequest request)
        {
            Tarefa tarefa = _tarefasServico.Instanciar(request.Nome, request.Detalhes);

            _tarefasServico.Inserir(tarefa);

            return _mapper.Map<TarefaResponse>(tarefa);
        }

        public PaginacaoResponse<TarefaResponse> Listar(TarefaListarRequest request)
        {
            var query = _tarefasRepositorio.Query();

            if (request.Nome != null)
                query.Where(x => x.Nome == request.Nome);

            Paginacao<Tarefa> tarefas = _tarefasRepositorio.Listar(query, request.Pagina, request.Quantidade);
            return _mapper.Map<PaginacaoResponse<TarefaResponse>>(tarefas);
        }

        public TarefaResponse Recuperar(string id)
        {
            Tarefa tarefa = _tarefasServico.Validar(id);
            return _mapper.Map<TarefaResponse>(tarefa);
        }
    }
}
