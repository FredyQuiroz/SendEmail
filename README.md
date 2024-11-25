# SendEmail

[Español](#español) · [English](#english)

## Español

Ejemplo en C# para probar cómo una aplicación web envía correo por SMTP. Sirve para comparar texto, HTML, archivos adjuntos e invitaciones de calendario en un entorno de pruebas.

### Esta revisión

**2024-11-25 · Probar envíos de correo SMTP desde C#.** Añade un servicio de ejemplo con rutas para enviar texto, HTML, adjuntos y citas de calendario. Usa una aplicación pequeña para poder comparar el resultado de cada tipo de mensaje en un entorno de pruebas.

### Cómo explorar el código

Consulta `TargetFramework` en los archivos `.csproj` para elegir la versión de .NET. Configura los servicios en local con credenciales de prueba. La ejecución de los flujos que dependen de integraciones necesita sus componentes y recursos de la época.

- [SendEmail.sln](SendEmail.sln)
- [SendEmail/Program.cs](SendEmail/Program.cs)
- [SendEmail/SendEmail.csproj](SendEmail/SendEmail.csproj)

## English

A C# example for testing how a web application sends mail over SMTP. It compares plain text, HTML, attachments, and calendar invitations in a controlled test setup.

### This revision

**2024-11-25 · Demonstrate SMTP mail from C#.** Add a sample service with endpoints for text, HTML, attachments, and calendar events. A small application lets readers compare the output of the different message types in a test environment.

### How to explore the source

Check `TargetFramework` in the `.csproj` files to select the .NET version. Configure services locally using test credentials. Workflows that depend on integrations require their historical components and resources.

- [SendEmail.sln](SendEmail.sln)
- [SendEmail/Program.cs](SendEmail/Program.cs)
- [SendEmail/SendEmail.csproj](SendEmail/SendEmail.csproj)

[Licencia / License](LICENSE)
