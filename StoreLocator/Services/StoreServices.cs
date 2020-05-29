using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using StoreLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreLocator.Services
{
    public class StoreServices
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Store> _stores;
        private readonly ILogger<StoreServices> _logger;

        public StoreServices(IStoreLocatorDbSettings settings, ILogger<StoreServices> logger)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _stores = _database.GetCollection<Store>(settings.StoresCollectionName);
            _logger = logger;
        }

        //the find method need a Func as an arguments
        public List<Store> Get() => _stores.Find(store => true).ToList();

        public Store Get(string id) => _stores.Find(store => store.Id == id).FirstOrDefault();

        public Store Insert(Store store)
        {
            if (store is null)
            {
                throw new ArgumentException("storeInput is null");
            }

            _logger.LogDebug("Inserting: {0}", JsonSerializer.Serialize(store));
            _stores.InsertOne(store);
            return store;
        }

        public void Update(string id, Store storeInput)
        {
            if(storeInput is null)
            {
                throw new ArgumentException("storeInput is null");
            }

            if(id != storeInput.Id)
            {
                throw new ArgumentException("storeInput has a different id from the one passed");
            }

            _logger.LogDebug("Updating: {0}", JsonSerializer.Serialize(storeInput));
            _stores.ReplaceOne(store => store.Id == id, storeInput);
        }

        public void Delete(string id) => _stores.DeleteOne(store => store.Id == id);
    }
}
