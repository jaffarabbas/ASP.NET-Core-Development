using System.Net.Mail;
using EmailSenderApi.Dtos;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmailSenderApi.Repository;

public class EmailRepository : IEmailRepository
{
    public void SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(""));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        var text = new TextPart(TextFormat.Html) { Text = request.Body };
        var multipart = new Multipart("mixed");
        multipart.Add(text);
        var attachment = new MimePart("application", "octet-stream")
        {
            Content = new MimeContent(File.OpenRead(@"")),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = Path.GetFileName(@"")
        };
        multipart.Add(attachment);
        email.Body = multipart;
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("", "");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}