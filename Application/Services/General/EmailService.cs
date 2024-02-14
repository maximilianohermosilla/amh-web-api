using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.IServices;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Application.UseCases
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {    
            _logger = logger;
        }

        public async Task<ResponseModel> SendEmail(EmailRequest request, string from, string password)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient sc = new SmtpClient();

                string html = string.Format("<html xmlns=\"http://www.w3.org/1999/xhtml\">  \r\n  \r\n<head>  \r\n    <title></title>  \r\n</head>  \r\n  \r\n<body>  \r\n  \r\n    <table>  \r\n  \r\n        <tr>  \r\n  \r\n            <td>  \r\n   \r\n                <span style=\"font-family:Arial;font-size:24px\">  \r\n  \r\nConsulta Formulario Web </span>  <br />    <div style=\"border-top:3px solid #033A66;margin: 10px 0;padding: 10px 0\"> </div>  \r\n  <b>Nombre: </b> {0} {1}<br />  \r\n <b>Email: </b> {2}<br />  \r\n <b>Whatsapp: </b> {3}<br />  \r\n <br />  \r\n {4}  \r\n  \r\n<br /><br />  \r\n  \r\n\r\n       <div style=\"border-top:3px solid #033A66;margin: 10px 0;padding: 10px 0\"> </div>  \r\n <img src=\"data:image/jpeg;base64,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\" width=\"150px\" height=\"60px\" />  \r\n                <br />  \r\n                </td>  \r\n  \r\n        </tr>  \r\n  \r\n    </table>  \r\n  \r\n</body>  \r\n  \r\n</html> ", request.Nombre, request.Apellido, request.Email, request.Whatsapp, request.Mensaje);

                mailMessage.From = new MailAddress(from);
                //mailMessage.To.Add("maximiliano_hermosilla@hotmail.com");
                mailMessage.To.Add(request.Destinatario);
                mailMessage.Subject = request.Asunto;
                mailMessage.Body = html;
                mailMessage.IsBodyHtml = true;

                sc.Host = "c2021803.ferozo.com";
                string str1 = "gmail.com";

                if (from.Contains(str1))
                {
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential(from, password);
                    sc.EnableSsl = true;
                    await sc.SendMailAsync(mailMessage);
                    _logger.LogInformation($"Detalles consulta formulario web. Nombre: {request.Nombre} {request.Apellido}. Email: {request.Email}. Whatsapp: {request.Whatsapp}. Mensaje: {request.Mensaje}");
                }
                else
                {                    
                    sc.Port = 587;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new System.Net.NetworkCredential(from, password);
                    sc.EnableSsl = true;
                    //sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    await sc.SendMailAsync(mailMessage);        
                    _logger.LogInformation($"Detalles consulta formulario web. Nombre: {request.Nombre} {request.Apellido}. Email: {request.Email}. Whatsapp: {request.Whatsapp}. Mensaje: {request.Mensaje}");
                }
                response.statusCode = 200;
                response.message = "Email enviado exitosamente";
                response.response = null;
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }
        }
    }
}
