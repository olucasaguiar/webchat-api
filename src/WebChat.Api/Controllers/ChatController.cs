using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebChat.Application.Interface;
using WebChat.Domain.Entity;

namespace WebChat.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> logger;
        private readonly IChatService service;

        public ChatController(ILogger<ChatController> logger, IChatService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public Task<IEnumerable<User>> Get()
        {
            return service.GetUsers()
                .ContinueWith(users =>
                {
                    logger.LogInformation(users.Result.Count().ToString());
                    return users.Result;
                });
        }

        [HttpGet("login")]
        public Task<string> GetLogin([FromQuery] string username)
        {
            var uuid = Guid.NewGuid().ToString();

            return service.Login(uuid, username)
                .ContinueWith(_ => uuid);
        }
    }
}
