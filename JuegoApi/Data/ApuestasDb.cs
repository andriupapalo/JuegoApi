using JuegoApi.Data.Configuration;
using JuegoApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoApi.Data
{
    public class ApuestasDb
    {
        private readonly IMongoCollection<Apuesta> _clientesCollection;

        public ApuestasDb(IClientesStoreDatabaseSettins settings)
        {
            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            //_clientesCollection = database.GetCollection<Ruleta>(settings.ClientesCollectionName);
            settings.ClientesCollectionName = "Apuestas";
            _clientesCollection = database.GetCollection<Apuesta>(settings.ClientesCollectionName);

        }
        public List<Apuesta> Get()
        {
            return _clientesCollection.Find(Apuesta => true).ToList();
        }
        public Apuesta GetById(string id)
        {
            return _clientesCollection.Find<Apuesta>(apuesta => apuesta.Id == id).FirstOrDefault();
        }
        public Apuesta Create(Apuesta book)
        {
            _clientesCollection.InsertOne(book);
            return book;
        }
        public void Update(string id, Apuesta cli)
        {
            _clientesCollection.ReplaceOne(apuesta => apuesta.Id == id, cli);
        }
        public void Delete(Apuesta cli)
        {
            _clientesCollection.DeleteOne(apuesta => apuesta.Id == cli.Id);
        }
        public void DeleteById(string id)
        {
            _clientesCollection.DeleteOne(apuesta => apuesta.Id == id);
        }
    }
}
