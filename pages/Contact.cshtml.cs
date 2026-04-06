using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;


namespace mallorca.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPostSendEmail(string Nombre, string Email, string Mensaje)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.tuservidor.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("tuemail@dominio.com", "tucontraseña"),
                    EnableSsl = true,
                };

                smtpClient.Send("tuemail@dominio.com", "destinatario@dominio.com",
                                "Mensaje de contacto",
                                $"Nombre: {Nombre}\nEmail: {Email}\nMensaje: {Mensaje}");
                ViewData["Message"] = "Correo enviado exitosamente";
            }
            catch
            {
                ViewData["Message"] = "Error al enviar el correo";
            }
        }
    }
}
