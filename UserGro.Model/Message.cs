using System;
using System.Collections.Generic;

namespace UserGro.Model
{
    public class Message
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IList<User> UsersTo { get; set; }
        public User UserFrom { get; set; }
        public string MessageBody { get; set; }
        public DateTime SentTime { get; set; }
    }
}