using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace KerberGestaoRegraDeNegocio.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration configuration;

        public Email(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                var host = "smtp-mail.outlook.com";
                var nome = "Kerber Móveis Planejados";
                var username = "kerbermoveisplanejados@outlook.com";
                var senha = "K&RBERM0veis";
                var porta = 587;

                var mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
