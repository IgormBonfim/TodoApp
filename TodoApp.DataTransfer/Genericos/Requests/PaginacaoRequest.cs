﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataTransfer.Genericos.Requests
{
    public class PaginacaoRequest
    {
        public int Pagina { get; set; } = 1;
        public int Quantidade { get; set; } = 20;
    }
}
