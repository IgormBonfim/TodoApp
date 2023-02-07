using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataTransfer.Tarefas.Responses;
using TodoApp.Dominio.Tarefas.Entidades;

namespace TodoApp.Aplicacao.Tarefas.Profiles
{
    public class TarefasProfile : Profile
    {
        public TarefasProfile()
        {
            CreateMap<Tarefa, TarefaResponse>();
        }
    }
}
