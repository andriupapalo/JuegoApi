using JuegoApi.Data.Configuration;
using JuegoApi.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoApi.Data
{
public class ClientesDb
{
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClientesDb(IClientesStoreDatabaseSettins settings)
    {
        var mdbClient = new MongoClient(settings.ConnectionString);
        var database = mdbClient.GetDatabase(settings.DatabaseName);
        _clientesCollection = database.GetCollection<Cliente>(settings.ClientesCollectionName);

    }
public List<Cliente> Get()
        {
            return _clientesCollection.Find(Ruleta=> true).ToList();
        }
public Cliente GetById(string id)
        {
            return _clientesCollection.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();
        }
public Cliente Create(Cliente book)
        {
            _clientesCollection.InsertOne(book);
            return book;
        }
public void Update(string id,Cliente cli)
        {
            _clientesCollection.ReplaceOne(cliente => cliente.Id == id, cli);
        }
public void Delete(Cliente cli)
        {
            _clientesCollection.DeleteOne(cliente => cliente.Id == cli.Id);
        }
public void DeleteById(string id)
        {
            _clientesCollection.DeleteOne(cliente => cliente.Id == id);
        }
}
}
