using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.Domain.Entity;

namespace WebChat.Domain.Interface
{
    public interface ISessionRepository
    {
        Task AddSession(string sessionKey, User user);

        Task<string> GetUserKey(string sessionKey);

        Task<IEnumerable<User>> GetAllUsers();
    }
}