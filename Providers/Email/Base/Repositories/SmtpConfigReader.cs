namespace raya_web.Providers.Email.Base.Repositories;

public class SmtpConfigReader
{
    static readonly string ConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "SandBox/config.json");

    public static EmailConfiguration GetEmailConfig()
    {
        var emailConfiguration = new EmailConfiguration();
        var builder = new ConfigurationBuilder().AddJsonFile(ConfigPath);
        var fetch = builder.Build().GetSection("smtp");
        emailConfiguration.SmtpServer = fetch.GetSection("SmtpServer").Value??"";
        emailConfiguration.UserName = fetch.GetSection("UserName").Value??"";
        emailConfiguration.SenderMail = fetch.GetSection("SenderMail").Value??"";
        emailConfiguration.Password = fetch.GetSection("Password").Value??"";
        emailConfiguration.Port = int.Parse(fetch.GetSection("Port").Value??"587");
        return emailConfiguration;
    }
}