using JuegoApi.Data.Configuration;
using JuegoApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoApi.Data
{
    public class RuletasDb
    {
        private readonly IMongoCollection<Ruleta> _clientesCollection;

        public RuletasDb(IClientesStoreDatabaseSettins settings)
        {
            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            //_clientesCollection = database.GetCollection<Ruleta>(settings.ClientesCollectionName);
            settings.ClientesCollectionName = "Ruletas";
            _clientesCollection = database.GetCollection<Ruleta>(settings.ClientesCollectionName);

        }
        public List<Ruleta> Get()
        {
            return _clientesCollection.Find(Ruleta => true).ToList();
        }
        public Ruleta GetById(string id)
        {
            return _clientesCollection.Find<Ruleta>(ruleta => ruleta.Id == id).FirstOrDefault();
        }
        public Ruleta Create(Ruleta book)
        {
            _clientesCollection.InsertOne(book);
            return book;
        }
        public void Update(string id, Ruleta cli)
        {
            _clientesCollection.ReplaceOne(ruleta => ruleta.Id == id, cli);
        }
        public void Delete(Ruleta cli)
        {
            _clientesCollection.DeleteOne(ruleta => ruleta.Id == cli.Id);
        }
        public void DeleteById(string id)
        {
            _clientesCollection.DeleteOne(ruleta => ruleta.Id == id);
        }
    }
}
