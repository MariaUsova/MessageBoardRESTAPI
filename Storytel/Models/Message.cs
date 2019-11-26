using System;

namespace Storytel
{
    public class Message
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public String Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
