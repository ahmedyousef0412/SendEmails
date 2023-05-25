using System.Collections.Generic;

namespace SendEmails.Dtos
{
    public class MailingRequestDto
    {

        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<IFormFile>? Attatchment { get; set; }
    }
}
