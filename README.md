# SendEmail

[Español](#español) · [English](#english)

## Español

Ejemplo en C# para probar cómo una aplicación web envía correo por SMTP. Sirve para comparar texto, HTML, archivos adjuntos e invitaciones de calendario en un entorno de pruebas.

### Qué puedes hacer

- Conserva rutas para enviar mensajes en texto, HTML o ambas formas.
- Incluye ejemplos de adjuntos y encabezados personalizados.
- Muestra cómo enviar una invitación de calendario.

### Ejemplo

Usa un servidor SMTP de pruebas que capture los mensajes y una dirección ficticia. Compara la salida de texto y la versión HTML en el capturador de correo.

### Cómo empezar

Consulta `TargetFramework` en los archivos `.csproj` para elegir la versión de .NET. Configura los servicios en local con credenciales de prueba. La ejecución de los flujos que dependen de integraciones necesita sus componentes y recursos de la época.

Puntos de entrada en el código. [`SendEmail.sln`](SendEmail.sln), [`SendEmail/Program.cs`](SendEmail/Program.cs), [`SendEmail/SendEmail.csproj`](SendEmail/SendEmail.csproj).

[Licencia MIT](LICENSE).

## English

A C# example for testing how a web application sends mail over SMTP. It compares plain text, HTML, attachments, and calendar invitations in a controlled test setup.

### What you can do

- Includes endpoints for plain text, HTML, or both formats.
- Includes attachment and custom header examples.
- Shows how to send a calendar invitation.

### Example

Use a test SMTP server that captures messages and a fictional address. Compare plain text and HTML output in the mail catcher.

### Getting started

Check `TargetFramework` in the `.csproj` files to select the .NET version. Configure services locally using test credentials. Workflows that depend on integrations require their historical components and resources.

Entry points in the source. [`SendEmail.sln`](SendEmail.sln), [`SendEmail/Program.cs`](SendEmail/Program.cs), [`SendEmail/SendEmail.csproj`](SendEmail/SendEmail.csproj).

[MIT license](LICENSE).
