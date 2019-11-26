using System;
using System.Collections.Generic;
using System.Linq;

namespace Storytel.Services
{
    public interface IMessagesService
    {
        List<Message> GetAll();

        Message GetById(Guid id);

        Message Add(string content, int userId);

        bool Delete(Message message);

        Message Update(Guid id, string content);
    }

    public class MessagesService : IMessagesService
    {
        private List<Message> _messages;

        public MessagesService()
        {
            _messages = new List<Message>();
        }

        public Message Add(string content, int userId)
        {
            var now = DateTime.UtcNow;
            var message = new Message
            {
                UserId = userId,
                Content = content,
                CreatedAt = now,
                UpdatedAt = now,
                Id = Guid.NewGuid()
            };

            _messages.Add(message);

            return message;
        }

        public bool Delete(Message message)
        {
            return _messages.Remove(message);
        }

        public List<Message> GetAll()
        {
            return _messages;
        }

        public Message GetById(Guid id)
        {
            return _messages.FirstOrDefault(x => x.Id == id);
        }

        public Message Update(Guid id, string content)
        {
            var existingMessage = GetById(id);
            if (existingMessage == null)
            {

                return null;
            }

            existingMessage.Content = content;
            existingMessage.UpdatedAt = DateTime.UtcNow;
            return existingMessage;
        }
    }
}
