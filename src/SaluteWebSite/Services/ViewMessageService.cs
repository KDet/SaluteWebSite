using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using SaluteWebSite.Data;
using SaluteWebSite.Models;
using SaluteWebSite.ViewModels.Message;

namespace SaluteWebSite.Services
{
    public class ViewMessageService
    {
        private readonly MessageRepository _messages = new MessageRepository();
        private readonly ApplicationDbContext _db;

        public ViewMessageService(MessageRepository messages, ApplicationDbContext dbContext)
        {
            _messages = messages;
            _db = dbContext;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync()
        {
            var messages = _messages.GetAll();
            var users = await _db.Users.ToDictionaryAsync(u => u.Id, u => u.Email);
            return messages.Select(m => new MessageViewModel
            {
                Id = m.Id,
                Created = m.Created,
                MessageTitle = m.MessageTitle,
                MessageContent = m.MessageContent,
                UserId = m.UserId,
                Username = users[m.UserId]
            }).ToArray();
        } 
    }
}
