namespace SweetManagerIotWebService.API.Shared.Infrastructure.miscellaneous.templates
{

    public static class MailTemplates
    {
        public static string GenerateAdminRequestToOrganization(
    string adminName,
    string adminFullName,
    string email,
    string phone,
    string additionalMessage,
    string ownerName,
    int hotelId)
    => $@"
    <!DOCTYPE html>
    <html>
        <head>
            <meta charset='UTF-8'>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f9f9f9;
                    padding: 20px;
                    color: #333;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    background-color: #ffffff;
                    border-radius: 8px;
                    box-shadow: 0 2px 5px rgba(0,0,0,0.1);
                    padding: 30px;
                }}
                .header img {{
                    max-width: 150px;
                    margin-bottom: 20px;
                }}
                .button {{
                    display: inline-block;
                    padding: 12px 24px;
                    background-color: #4CAF50;
                    text-decoration: none;
                    border-radius: 5px;
                    margin-top: 20px;
                }}
                .info {{
                    margin-top: 20px;
                    line-height: 1.6;
                }}
                .footer {{
                    margin-top: 30px;
                    font-size: 0.9em;
                    color: #777;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <!-- Replace src with your logo URL -->
                    <img src='https://i.imgur.com/vJdKucg.png' alt='Sweet Manager Logo'>
                </div>
                <p>Hola <strong>{ownerName}</strong>,</p>

                <p>
                    El administrador <strong>{adminName}</strong> ha enviado una solicitud para unirse a su organización en <strong>Sweet Manager</strong>.
                </p>

                <div class='info'>
                    <h4>📄 Información del solicitante:</h4>
                    <ul>
                        <li><strong>Nombre completo:</strong> {adminFullName}</li>
                        <li><strong>Correo electrónico:</strong> {email}</li>
                        <li><strong>Teléfono:</strong> {phone}</li>
                        <li><strong>Mensaje adicional:</strong> {additionalMessage}</li>
                    </ul>
                </div>

                <p>🛠️ <strong>Acción sugerida:</strong><br>
                    Si desea agregar a este administrador, puede hacerlo desde la sección de ""Administradores"" en su panel de control.
                </p>

                <a href = 'https://sweet-manager-web-application.vercel.app/home/hotel/{hotelId}/organization' class='button'>
                    Agregar administrador
                </a>

                <div class='footer'>
                    <p>Gracias por utilizar<strong> Sweet Manager</strong>.</p>
                    <p>Atentamente,<br>El equipo de Sweet Manager</p>
                </div>
            </div>
        </body>
    </html>
    ";
    }
}