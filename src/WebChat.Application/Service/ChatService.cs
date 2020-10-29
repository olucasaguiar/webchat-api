using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebChat.Application.Interface;
using WebChat.Domain.Entity;
using WebChat.Domain.Interface;

namespace WebChat.Application.Service
{
    public class ChatService : Hub, IChatService
    {
        private readonly ISessionRepository connections;

        public ChatService(ISessionRepository connections)
        {
            this.connections = connections;
        }

        /// <summary>
        /// Método responsável por encaminhar as mensagens pelo hub
        /// </summary>
        /// <param name="message">Este parâmetro é nosso objeto representando a mensagem e os usuários envolvidos</param>
        /// <returns></returns>
        public Task SendMessage(Message message)
        {
            //Ao usar o método Client(_connections.GetUserId(chat.destination)) eu estou enviando a mensagem apenas para o usuário destino, não realizando broadcast
            return connections.GetUserKey(message.Destination)
                .ContinueWith(userKey => Clients.Client(userKey.Result)
                    .SendAsync("Receive", message.Sender, message.TextMessage));
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return connections.GetAllUsers();
        }

        public Task Login(string userId, string userName)
        {
            return connections.AddSession(userId, new User(userId, userName));
        }
    }
}