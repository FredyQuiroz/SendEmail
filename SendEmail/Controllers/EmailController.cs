using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Ical.Net;
using Microsoft.Extensions.Options;
using MimeKit;
using SendEmail.Options;
using SendEmail.Services;
using System.Text;

namespace SendEmail.Controllers
{
    public class EmailController
    {
        public readonly SmtpService _smtpService;
        public readonly SmtpOptions _smtpOptions;

        public EmailController(SmtpService smtpService, IOptionsMonitor<SmtpOptions> smtpOptions)
        {
            _smtpService = smtpService;
            _smtpOptions = smtpOptions.CurrentValue;
        }

        public SmtpOptions GetSmtpOptions()
        {
            return _smtpOptions;
        }

        public async Task<bool> SendAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "Text Sample Email";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "This is a sample email sent from a .NET 6 application."
            };

            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }

        public async Task<bool> SendHtmlAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "HTML Sample Email";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<h1>This is a sample email sent from a .NET 6 application.</h1>"
            };

            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }

        public async Task<bool> SendHtmlAndTextAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "HTML and Text Sample Email";

            var builder = new BodyBuilder
            {
                HtmlBody = "<h1>This is a sample email sent from a .NET 6 application.</h1>",
                TextBody = "This is a sample email sent from a .NET 6 application."
            };

            message.Body = builder.ToMessageBody();

            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }

        public async Task<bool> SendAttachmentAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "Attachment Sample Email";

            var builder = new BodyBuilder
            {
                HtmlBody = "<h1>This is a sample email with an attachment sent from a .NET 6 application.</h1>",
                TextBody = "This is a sample email with an attachment sent from a .NET 6 application."
            };
            builder.Attachments.Add("sample.txt", new MemoryStream(Encoding.UTF8.GetBytes("This is a sample text file.")));

            message.Body = builder.ToMessageBody();

            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }

        public async Task<bool> SendHeadersAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "Headers Sample Email";
            message.Headers.Add("List-Unsubscribe", $"<https://www.example.com/unsubscribe?user=recipient@example.com>");

            message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "This is a sample email with a List-Unsubscribe header sent from a .NET 6 application."
            };
            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }

        public async Task<bool> SendCalendarAsync(CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sender Name", "sender@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));

            message.Subject = "Calendar Sample Email";

            var builder = new Multipart("mixed");
            builder.Add(new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "This is a sample email with a calendar attachment sent from a .NET 6 application."
            });
            builder.Add(new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<h1>This is a sample email with a calendar attachment sent from a .NET 6 application.</h1>"
            });

            var calendarPart = new TextPart("calendar") { Text = CreateSampleEvent(), ContentTransferEncoding = ContentEncoding.Base64 };
            calendarPart.ContentType.Parameters.Add("method", "REQUEST");

            builder.Add(calendarPart);

            message.Body = builder;

            await _smtpService.SendAsync(message, cancellationToken);
            return true;
        }



        private static string CreateSampleEvent()
        {
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = startDate.AddHours(1);

            var calendar = new Calendar();
            calendar.Method = "REQUEST";

            var calendarEvent = new CalendarEvent
            {
                Summary = "Team meeting",
                Description = "This is a sample event for a team meeting to discuss project updates.",
                Start = new CalDateTime(startDate),
                End = new CalDateTime(endDate),
                Attendees = new List<Attendee>() {
                    new Attendee() {
                        CommonName= "John Doe",
                        ParticipationStatus = "REQ-PARTICIPANT",
                        Rsvp = true,
                        Value=new Uri($"mailto:johndoe@example.com")
                    }
                },
                Organizer = new Organizer()
                {
                    CommonName = "Jane Smith",
                    Value = new Uri("mailto:janesmith@example.com")
                }
            };
            calendarEvent.Alarms.Add(new Alarm()
            {
                Action = AlarmAction.Display,
                Description = "Meeting Reminder",
                Trigger = new Trigger(TimeSpan.FromMinutes(-15))
            });

            calendar.Events.Add(calendarEvent);

            var serializer = new CalendarSerializer();
            return serializer.SerializeToString(calendar);
        }
    }
}
