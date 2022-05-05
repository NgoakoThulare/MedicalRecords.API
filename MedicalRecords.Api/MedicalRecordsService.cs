using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MedicalRecords.Api
{
    public class MedicalRecordsService : IMedicalRecordsService
    {
        private string smtpHost => "smtp-relay.gmail.com";
        private int smtpPort => 587;
        public async Task<bool> SendEmail(Request request)
        {
            try
            {
                var smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                };

                var message = new MailMessage(
                "no-reply-medicalrecords@gmail.com",
                "marcothulare@gmail.com",
                request.Subject,
                request.Body)
                {
                    IsBodyHtml = true,
                };

                message.To.Add("ngoako.thulare@capitecbank.co.za");

                var bytes = Convert.FromBase64String(request.Files[0]);
                var stream = new MemoryStream(bytes);
                var data = new Attachment(stream, "MedicalRecord" + ".pdf");
                var disposition = data.ContentDisposition;
                data.ContentId = "MedicalRecord";
                data.ContentDisposition.Inline = true;
                message.Attachments.Add(data);

                await smtpClient.SendMailAsync(message);

                smtpClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
