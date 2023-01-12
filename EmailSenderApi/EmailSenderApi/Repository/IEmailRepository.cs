using EmailSenderApi.Dtos;

namespace EmailSenderApi.Repository;

public interface IEmailRepository
{
    void SendEmail(EmailDto request);
}