using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.Domain.Entity;

namespace WebChat.Application.Interface
{
    public interface IChatService
    {
        Task SendMessage(Message chat);

        Task<IEnumerable<User>> GetUsers();

        Task Login(string userId, string userName);
    }
}