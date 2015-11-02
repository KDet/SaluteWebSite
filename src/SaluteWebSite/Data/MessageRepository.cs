using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SaluteWebSite.Models;

namespace SaluteWebSite.Data
{
    public class MessageRepository
    {
        private static readonly List<Message> Messages = new List<Message>();
        private static int IdCount;
        private const string UserIdOne = "1b92a47c-7aff-4143-9719-9dc99ff14f11";
        private const string UserIdTwo = "1c8e7c7a-24bd-40e5-adc3-fe403a66d8fc";

        static MessageRepository()
        {
            Messages.Add(new Message
            {
                Id = GetNextId(),
                UserId = UserIdOne,
                Created = new DateTime(2015, 6, 1),
                MessageTitle = "First Message Title",
                MessageContent = "First Message Content"
            });
            Messages.Add(new Message
            {
                Id = GetNextId(),
                UserId = UserIdTwo,
                Created = new DateTime(2015, 6, 2),
                MessageTitle = "Second Message Title",
                MessageContent = "Second Message Content"
            });
            Messages.Add(new Message
            {
                Id = GetNextId(),
                UserId = UserIdTwo,
                Created = new DateTime(2015, 6, 3),
                MessageTitle = "Third Message Title",
                MessageContent = "Third Message Content"
            });
        }

        public Message GetById(int id)
        {
            return Messages.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Message message)
        {
        }

        public void Add(Message message)
        {
            message.Id = GetNextId();
            Messages.Add(message);
        }

        private static int GetNextId()
        {
            return ++IdCount;
        }

        public IEnumerable<Message> GetAll()
        {
            return Messages.ToArray();
        }
    }
}
