using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLocator.Models
{
    public interface IStoreLocatorDbSettings
    {
        string StoresCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
