using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SendEmail.Options;

namespace SendEmail.Services
{
    public class SmtpService
    {
        public readonly SmtpOptions _options;

        public SmtpService(IOptionsMonitor<SmtpOptions> options)
        {
            _options = options.CurrentValue;
        }

        public async Task SendAsync(MimeMessage message, CancellationToken cancellationToken = default)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Server, _options.Port ?? 25, _options.UseSsl, cancellationToken);
            if(!string.IsNullOrEmpty(_options.Username))
                await client.AuthenticateAsync(_options.Username, _options.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}
