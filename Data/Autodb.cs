using System.Collections.Generic;
using apiautos.Data.Configuration;
using apiautos.Entities;
using MongoDB.Driver;

namespace apiautos.Data
{
    public class Autodb
    {
         private readonly IMongoCollection<Marca> _autosCollection;

        public Autodb(IAutosSettings settings)
        {
            // var mdbClient = new MongoClient(settings.ConnectionString);
            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);

            _autosCollection = database.GetCollection<Marca>(settings.AutosCollectionName);
        }

        public List<Marca> Get()
        {
            return _autosCollection.Find(cli => true).ToList();
        }

        public Marca GetById(string id)
        {
            return _autosCollection.Find<Marca>(marca => marca.Id == id).FirstOrDefault();
        }

        public Marca Create(Marca marc)
        {
            _autosCollection.InsertOne(marc);
            return marc;
        }

        public void Update(string id, Marca marc)
        {
            _autosCollection.ReplaceOne(marca => marca.Id == id, marc);
        }

        public void Delete(Marca marc)
        {
            _autosCollection.DeleteOne(marca => marca.Id == marc.Id);
        }

        public void DeleteById(string id)
        {
            _autosCollection.DeleteOne(Marca => Marca.Id == id);
        }
    }
}