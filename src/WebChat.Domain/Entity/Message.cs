namespace WebChat.Domain.Entity
{
    public class Message
    {
        public string Destination { get; protected set; }
        public User Sender { get; protected set; }
        public string TextMessage { get; protected set; }
    }
}