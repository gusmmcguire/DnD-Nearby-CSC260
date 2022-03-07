using System;
using System.Collections.Generic;
using System.Linq;

namespace DnD_Nearby.Settings
{
    public class MongoDbConfig
    {
        public string Name { get; init; }
        public string Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb+srv://{Host}";
    }
}
