using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Domain.Entity;
using WebChat.Domain.Interface;

namespace WebChat.Infra.InMemoryDatabase.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly Dictionary<string, User> connections;

        public SessionRepository()
        {
            connections = new Dictionary<string, User>();
        }

        public Task AddSession(string sessionKey, User user)
        {
            System.Console.WriteLine(sessionKey);
            System.Console.WriteLine(connections.ContainsKey(sessionKey));

            return Task.Run(() =>
            {
                if (!connections.ContainsKey(sessionKey))
                    connections.Add(sessionKey, user);
            });
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return Task.Run(() => connections
                .Select(cnn => cnn.Value)
                .AsEnumerable());
        }

        public Task<string> GetUserKey(string sessionKey)
        {
            return Task.Run(() => connections
                .Where(cnn => cnn.Key == sessionKey)
                .Select(user => user.Value.Key)
                .First());
        }
    }
}