using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to,string Subject,string Content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            this.Subject = Subject;
            this.Content = Content;

        }
    }
}
