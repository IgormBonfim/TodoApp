using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infra.Builders;
using TodoApp.Infra.Configs.Interfaces;

namespace TodoApp.Infra.Configs
{
    public class MongoDatabaseConfiguration : IMongoDatabaseConfiguration
    {
        public IMongoClient? MongoClient { get; set; }
        public IMongoDatabase? MongoDatabase { get; set; }

        public MongoDatabaseConfiguration ConfigureClient(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
            return this;
        }

        public MongoDatabaseConfiguration ConfigureDatabaseName(string databaseName)
        {
            if (MongoClient == null)
                throw new Exception("Client não configurado.");

            MongoDatabase = MongoClient.GetDatabase(databaseName);
            return this;
        }
    }
}
