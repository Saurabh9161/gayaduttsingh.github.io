using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace gayaduttsingh.Models
{
    public class EmailSender
    {
        public string SendTo { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
        public string CC { get; set; }
        public string AttachmentFile { get; set; }
        public bool SenderEmail()
        {
            SmtpClient Smpt = new SmtpClient();
            MailMessage msg = new MailMessage();
            MailAddress from = new MailAddress("saurabh.data.91@gmail.com");

            MailAddress to = new MailAddress("saurabh.data.91@gmail.com");
            //networks cridentials settings starts here 
            NetworkCredential nc = new NetworkCredential("saurabh.data.91@gmail.com", "S9161238958S");
            Smpt.EnableSsl = true;
            Smpt.UseDefaultCredentials =false;
            Smpt.Host ="smtp.gmail.com";
            Smpt.Port =587;
            Smpt.Credentials = nc;
            //networks credentials settings here.......
             
            //MailMessage setting start here....
            msg.Sender=from;
            msg.Subject=Subject;
            msg.To.Add(to);
            msg.From=from;
            msg.Body= MessageBody;
            if(CC !=null)
            {
                Attachment att=new Attachment
                (HttpContext.Current.Server.MapPath(AttachmentFile));
                msg.Attachments.Add(att);
            }
            //mail message setting end here....
            //now send message
            Smpt.Send(msg);

            return true;
        }
    }
}
