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
        public static void SendMail(string Smtp, string From, string To, string Subject, string Body, string Username, string Password, string MsgBoxSuccess = "")
        {
            using (SmtpClient SmtpServer = new SmtpClient(Smtp))
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(From);
                mail.To.Add(To);
                mail.Subject = Subject;
                mail.Body = Body;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Username, Password);
                SmtpServer.EnableSsl = true;
                try
                {
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    SmtpServer.Dispose();
                }
                if (MsgBoxSuccess != "")
                    MessageBox.Show(MsgBoxSuccess);
            }
        }

    }
}
