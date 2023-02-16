using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dominio.Genericos.Entidades;
using TodoApp.Dominio.Genericos.Interfaces;
using TodoApp.Dominio.Tarefas.Entidades;
using TodoApp.Infra.Configs;
using TodoApp.Infra.Configs.Interfaces;

namespace TodoApp.Infra.Genericos
{
    public class MongoRepositorio<T> : IMongoRepositorio<T> where T : Entidade
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public MongoRepositorio(IMongoDatabaseConfiguration mongoDataBaseConfiguration, string collection)
        {
            _mongoCollection = mongoDataBaseConfiguration.MongoDatabase.GetCollection<T>(collection);
        }

        public T Adicionar(T entidade)
        {
            _mongoCollection.InsertOne(entidade);
            return entidade;
        }

        public T Atualizar(string id, T entidade)
        {
            _mongoCollection.ReplaceOne(entidade => entidade.Id == id, entidade);
            return entidade;
        }

        public void Excluir(string id)
        {
            _mongoCollection.DeleteOne(entidade => entidade.Id == id);
        }

        public IList<T> Listar()
        {
            return _mongoCollection.Find(entidade => true).ToList();
        }

        public T Recuperar(string id)
        {
            return _mongoCollection.Find(entidade => entidade.Id == id).FirstOrDefault();
        }
    }
}
