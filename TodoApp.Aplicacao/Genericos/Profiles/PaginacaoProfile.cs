using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataTransfer.Genericos.Responses;
using TodoApp.Dominio.Genericos.Entidades;

namespace TodoApp.Aplicacao.Genericos.Profiles
{
    public class PaginacaoProfile : Profile
    {
        public PaginacaoProfile()
        {
            CreateMap(typeof(Paginacao<>), typeof(PaginacaoResponse<>));
        }
    }
}
