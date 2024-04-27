using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace SendMailExample;

public class Mailer
{
    public void SendEmail(string email, string subject, string messageBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("FromName", "fromAddress@gmail.com"));
        message.To.Add(new MailboxAddress("", email));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = messageBody };

        using var client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        client.Authenticate("yourEmail@gmail.com", "yourGeneratedPassword");
        client.Send(message);
        client.Disconnect(true);
    }
}