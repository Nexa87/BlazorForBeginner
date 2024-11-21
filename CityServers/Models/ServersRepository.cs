using System.Data;
using System.Reflection;
using System.Xml.Serialization;

namespace CityServers.Models
{
    public static class ServersRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server { ServerId = 1, Name = "Server 1", City = "Toronto"},
            new Server { ServerId = 2, Name = "Server 2", City = "Toronto"},
            new Server { ServerId = 3, Name = "Server 3", City = "Toronto"},
            new Server { ServerId = 4, Name = "Server 4", City = "Toronto"},
            new Server { ServerId = 5, Name = "Server 5", City = "Montreal"},
            new Server { ServerId = 6, Name = "Server 6", City = "Montreal"},
            new Server { ServerId = 7, Name = "Server 7", City = "Calgary"},
            new Server { ServerId = 8, Name = "Server 8", City = "Calgary"},
            new Server { ServerId = 9, Name = "Server 9", City = "Ottawa"},
            new Server { ServerId = 10, Name = "Server 10", City = "Ottawa"},
            new Server { ServerId = 11, Name = "Server 11", City = "Ottawa"},
            new Server { ServerId = 12, Name = "Server 12", City = "Ottawa"},
            new Server { ServerId = 13, Name = "Server 13", City = "Hallifax"},
            new Server { ServerId = 14, Name = "Server 14", City = "Hallifax"},
            new Server { ServerId = 15, Name = "Server 15", City = "Hallifax"}
        };

        public static void AddServer(Server server)
        {
            var maxID = servers.Max(x => x.ServerId);
            server.ServerId = maxID + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName,StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == id);

            if (server != null)
            {
                return new Server
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }

            // Hvis serveren ikke findes, returnér null
            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;
            
            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;                
            }
        }
        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
