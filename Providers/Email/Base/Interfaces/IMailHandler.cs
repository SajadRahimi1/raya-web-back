
public interface IMailHandler
{
    Task<SmtpServerResponse> SendEmailAsync(MailRequest mailRequest);
}