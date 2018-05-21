using System;
using System.Configuration;
using StackExchange.Redis;

namespace BookStore
{
    public static class Redis
    {
        private static readonly Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => 
            ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["Redis"].ConnectionString));

        public static ConnectionMultiplexer RedisConnection => lazyConnection.Value;
    }
}