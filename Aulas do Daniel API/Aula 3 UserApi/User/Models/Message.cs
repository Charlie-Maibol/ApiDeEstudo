using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UserAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> Recipient { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> recipient, string subject,
            int userId, string code)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress(d)));
            Subject = subject;
            Content = $"http://Localhost:6000/confirm?UserId=(userId)&ConfirmUser=(code)";
        }
    }
}
