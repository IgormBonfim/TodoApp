using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataTransfer.Tarefas.Requests;
using TodoApp.DataTransfer.Tarefas.Responses;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Enumeradores;
using TodoApp.Dominio.Tarefas.Servicos.Comandos;

namespace TodoApp.Aplicacao.Tarefas.Profiles
{
    public class TarefasProfile : Profile
    {
        public TarefasProfile()
        {
            CreateMap<Tarefa, TarefaResponse>();
            CreateMap<TarefaAtualizarRequest, TarefaAtualizarComando>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(StatusTarefaEnum), source.Status)));
        }
    }
}
