using MailKit.Security;
using MimeKit;
using raya_web.Providers.Email.Base.Repositories;
using ContentType = MimeKit.ContentType;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


public class MailHandler : IMailHandler
{
    private readonly EmailConfiguration _configuration=SmtpConfigReader.GetEmailConfig();
    private static SmtpClient _smtpClient;

    public async Task<SmtpServerResponse> SendEmailAsync(MailRequest mailRequest)
    {
        var response = new SmtpServerResponse();
        try
        {
            await SmtpConnect();
            var email = new MimeMessage();
            if (_configuration.SenderMail is not null) email.Sender = MailboxAddress.Parse(_configuration.SenderMail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            if (mailRequest.Attachments?.Any() ?? false)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var fileBytes = memoryStream.ToArray();
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            response.SmtpResponse= await _smtpClient.SendAsync(email);
            response.IsSuccessful = true;
            return response;
        }
        catch (Exception e)
        {
            response.SmtpResponse= e.Message;
            return response;
        }
    }

    private async Task SmtpConnect()
    {
        if (_smtpClient?.IsConnected ?? false) return;

        _smtpClient = new SmtpClient();
        _smtpClient.CheckCertificateRevocation = false;
        _smtpClient.Timeout =(int)TimeSpan.FromHours(1).TotalMilliseconds;
        await _smtpClient.ConnectAsync(_configuration.SmtpServer, _configuration.Port,
            SecureSocketOptions.StartTlsWhenAvailable);
        await _smtpClient.AuthenticateAsync(_configuration.UserName, _configuration.Password);
    }
}