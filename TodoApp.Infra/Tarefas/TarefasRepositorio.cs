using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Dominio.Tarefas.Repositorios;
using TodoApp.Infra.Configs.Interfaces;

namespace TodoApp.Infra.Tarefas
{
    public class TarefasRepositorio : ITarefasRepositorio
    {
        private readonly IMongoCollection<Tarefa> _mongoCollection;

        public TarefasRepositorio(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _mongoCollection = database.GetCollection<Tarefa>("tarefas");
        }

        public void Adicionar(Tarefa tarefa)
        {
            _mongoCollection.InsertOne(tarefa);
        }

        public void Atualizar(string id, Tarefa tarefa)
        {
            _mongoCollection.ReplaceOne(id, tarefa);
        }

        public void Excluir(string id)
        {
            _mongoCollection.DeleteOne(id);
        }

        public IEnumerable<Tarefa> Listar()
        {
            return _mongoCollection.Find(tarefa => true).ToList();
        }

        public Tarefa Recuperar(string id)
        {
            return _mongoCollection.Find(id).FirstOrDefault();
        }
    }
}
