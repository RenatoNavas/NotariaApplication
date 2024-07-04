using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MimeKit.Text;
using MailKit.Net.Smtp;

namespace ProyectoLogin.Services
{
    public static class CorreoServicio
    {
        private static string _Host = "smtp.gmail.com";
        private static int _Puerto = 587;

        private static string _NombreEnvia = "Notaria85";
        private static string _Correo = "navasrenato5@gmail.com";
        private static string _Clave = "onjwbsexmxsijeyl ";

        public static bool Enviar(Correo correodto)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress(_NombreEnvia, _Correo));
                email.To.Add(MailboxAddress.Parse(correodto.Para));
                email.Subject = correodto.Asunto;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = correodto.Contenido
                };

                var smtp =new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_Host, _Puerto, SecureSocketOptions.StartTls);

                smtp.Authenticate(_Correo, _Clave);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
