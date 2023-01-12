using EmailSenderApi.Dtos;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EmailSenderApi.Repository;

public class EmailRepository : IEmailRepository
{
    public void SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(""));
        email.To.Add(MailboxAddress.Parse(request.To));
        
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("", "");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}