# SendEmail Project

## Overview
SendEmail is a C# .NET 8 project designed to demonstrate how to send emails through various methods using an SMTP server. It provides different email functionalities such as sending plain text emails, HTML emails, emails with attachments, and even calendar event invitations.

## Features
- **Plain Text Email**: Send basic emails with plain text content.
- **HTML Email**: Send emails with HTML-formatted content.
- **Mixed Text and HTML Email**: Send emails containing both text and HTML content.
- **Email with Attachments**: Attach files to the email before sending.
- **Email with Headers**: Send emails with custom headers, such as unsubscribe links.
- **Calendar Event Email**: Send calendar invitations via email using the iCal format.

## Project Structure
- **Program.cs**: Entry point for the application, sets up the necessary services and routes to handle different email operations.
- **SmtpService.cs**: A service responsible for interacting with the SMTP server and sending emails using MailKit.
- **SmtpOptions.cs**: Defines configuration options required for the SMTP server, including server address, port, username, password, and SSL options.
- **EmailController.cs**: Handles different email operations, such as sending emails in plain text, HTML, with attachments, headers, and calendar invitations.

## Prerequisites
- **.NET 6 SDK**: The project is developed using .NET 6, so the appropriate SDK is required.
- **SMTP Server Credentials**: You will need access to an SMTP server and credentials for authentication.

## Configuration
In order to configure the SMTP options, add the SMTP settings to your appsettings.json file:

```json
{
  "Smtp": {
    "Server": "smtp.example.com",
    "Port": 587,
    "Username": "your_username",
    "Password": "your_password",
    "UseSsl": true
  }
}
```

## Running the Project
1. **Clone the repository**:
   ```sh
   git clone https://github.com/fredyquiroz/sendemail.git
   cd sendemail
   ```
2. **Build the project**:
   ```sh
   dotnet build
   ```
3. **Run the project**:
   ```sh
   dotnet run
   ```

The project exposes several endpoints to test email functionality:
- `/email/options`: Get the current SMTP configuration.
- `/email/send`: Send a plain text email.
- `/email/sendhtml`: Send an HTML email.
- `/email/sendhtmlandtext`: Send an email with both HTML and plain text content.
- `/email/sendattachment`: Send an email with an attachment.
- `/email/sendheaders`: Send an email with custom headers.
- `/email/sendcalendar`: Send an email with a calendar event.

## Usage
To test the endpoints, you can use any HTTP client like [Postman](https://www.postman.com/) or simply use a browser for GET requests. For example, to send a plain text email, make a GET request to:

```
http://localhost:5000/email/send
```

## Dependencies
- **MailKit**: Used for SMTP client implementation.
- **Ical.Net**: Used for generating calendar events to send as attachments.

## License
This project is licensed under the MIT License.

## Author
- **Fredy Quiroz** - [GitHub Profile](https://github.com/fredyquiroz)

Feel free to contribute to the project by submitting issues or pull requests!

