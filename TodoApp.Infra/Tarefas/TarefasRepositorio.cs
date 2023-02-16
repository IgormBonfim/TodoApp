using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Infra.Configs.Interfaces;
using TodoApp.Infra.Genericos;

namespace TodoApp.Infra.Tarefas
{
    public class TarefasRepositorio : MongoRepositorio<Tarefa>, ITarefasRepositorio
    {
        public TarefasRepositorio(IMongoDatabaseConfiguration mongoDatabaseConfiguration) : base(mongoDatabaseConfiguration, "tarefas") { }
    }
}
