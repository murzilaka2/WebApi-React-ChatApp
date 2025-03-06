using ChatServer.Models;
using System.Collections.Concurrent;

namespace ChatServer.Data
{
    public class ShareDb
    {
        private readonly ConcurrentDictionary<string, UserConnection> connections;
        public ConcurrentDictionary<string, UserConnection> Connections => connections;
        public ShareDb()
        {
            connections = new ConcurrentDictionary<string, UserConnection>();
        }
    }
}
