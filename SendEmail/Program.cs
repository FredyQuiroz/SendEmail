using SendEmail.Controllers;
using SendEmail.Options;
using SendEmail.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddTransient<SmtpService>();
builder.Services.AddScoped<EmailController>();

var app = builder.Build();

app.MapGet("/email/options", (EmailController controller) => controller.GetSmtpOptions());
app.MapGet("/email/send", async (EmailController controller) => await controller.SendAsync());
app.MapGet("/email/sendhtml", async (EmailController controller) => await controller.SendHtmlAsync());
app.MapGet("/email/sendhtmlandtext", async (EmailController controller) => await controller.SendHtmlAndTextAsync());
app.MapGet("/email/sendattachment", async (EmailController controller) => await controller.SendAttachmentAsync());
app.MapGet("/email/sendheaders", async (EmailController controller) => await controller.SendHeadersAsync());
app.MapGet("/email/sendcalendar", async (EmailController controller) => await controller.SendCalendarAsync());

app.Run();
