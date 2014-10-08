using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace SharpMail
{
    public static class Mail
    {
        public static void SendMail(string SMTP, string FROM, string TO, string SUBJECT, string BODY, string USERNAME, string PASSWORD, bool MSGBOXSUCCESS)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP);
                mail.From = new MailAddress(FROM);
                mail.To.Add(TO);
                mail.Subject = SUBJECT;
                mail.Body = BODY;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(USERNAME, PASSWORD);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                SmtpServer.Dispose();
                if(MSGBOXSUCCESS)
                    MessageBox.Show("Mail send !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
