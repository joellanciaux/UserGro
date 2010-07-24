using System;
using System.Collections.Generic;

namespace UserGro.Model
{
    public class Message
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IList<User> Recipients { get; set; }
        public User Sender { get; set; }
        public string MessageBody { get; set; }
        public DateTime SentTime { get; set; }

        public Message()
        {
            Recipients = new List<User>();
        }
    }
}