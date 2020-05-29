using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLocator.Models
{
    public class StoreLocatorDbSettings : IStoreLocatorDbSettings
    {
        public string StoresCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
