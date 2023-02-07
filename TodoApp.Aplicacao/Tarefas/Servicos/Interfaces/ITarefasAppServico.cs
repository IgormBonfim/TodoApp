﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataTransfer.Tarefas.Requests;
using TodoApp.DataTransfer.Tarefas.Responses;

namespace TodoApp.Aplicacao.Tarefas.Servicos.Interfaces
{
    public interface ITarefasAppServico
    {
        TarefaResponse Inserir(TarefaInserirRequest request);
    }
}
