using System;

namespace WebChat.Domain.Entity
{
    public class User
    {
        public User(string key, string name)
        {
            Key = key;
            Name = name;
            DateConnection = DateTime.Now;
        }

        public string Name { get; protected set; }
        public string Key { get; protected set; }
        public System.DateTime DateConnection { get; protected set; }
    }
}