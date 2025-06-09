namespace SweetManagerIotWebService.API.Shared.Infrastructure.miscellaneous.templates
{

    public static class MailTemplates
    {
        public static string GenerateAdminRequestToOrganization(string adminName, string adminFullName,string email, string phone, string additionalMessage, string ownerName, int hotelId)
         => (
            $"Hola {ownerName},\r\n\r\nEl administrador {adminName} ha enviado una solicitud para unirse a su organización en Sweet Manager.\r\n\r\n📄 Información del solicitante:\r\n- Nombre completo: {adminFullName}\r\n- Correo electrónico: {email}\r\n- Teléfono: {phone}\r\n- Mensaje adicional (opcional): {additionalMessage}\r\n\r\n🛠️ Acción sugerida:\r\nSi desea agregar a este administrador, puede enviarle una invitación desde la sección de \"Administradores\" en su panel de control.\r\n\r\n<a href=\"https://sweet-manager-web-application.vercel.app/home/hotel/{hotelId}/organization\" style=\"padding:10px 20px;background-color:#4CAF50;color:white;text-decoration:none;border-radius:5px;\">Agregar</a>\r\n\r\nGracias por utilizar Sweet Manager.\r\n\r\nAtentamente,  \r\nEl equipo de Sweet Manager"
        );
    }
}