using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Aplicacao.Tarefas.Servicos.Interfaces;
using TodoApp.DataTransfer.Tarefas.Requests;
using TodoApp.DataTransfer.Tarefas.Responses;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Servicos.Interfaces;

namespace TodoApp.Aplicacao.Tarefas.Servicos
{
    public class TarefasAppServico : ITarefasAppServico
    {
        private readonly ITarefasServico _tarefasServico;
        private readonly IMapper _mapper;

        public TarefasAppServico(ITarefasServico tarefasServico, IMapper mapper)
        {
            this._tarefasServico = tarefasServico;
            this._mapper = mapper;
        }

        public TarefaResponse Inserir(TarefaInserirRequest request)
        {
            Tarefa tarefa = _tarefasServico.Instanciar(request.Nome, request.Detalhes);

            _tarefasServico.Inserir(tarefa);

            return _mapper.Map<TarefaResponse>(tarefa);
        }
    }
}
