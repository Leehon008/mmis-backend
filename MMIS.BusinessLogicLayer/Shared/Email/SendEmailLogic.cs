using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.SHE.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MMIS.BusinessLogicLayer.Shared.Email
{
    public class SendEmailLogic : ISendEmailLogic
    {
        public readonly MMISDbContext _context;
        public SendEmailLogic(MMISDbContext context)
        {
            _context = context;
        }
        public void sendEmail(IncidentLogging incidentLogging)
        {

            //var emails = _context.SHEMails.W
            var author = _context.SHEMails.Where(a=>a.Plant == incidentLogging.Centre && a.Department == incidentLogging.DepartmentWhereOcurred ).Single();
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("businfo@delta.co.zw", "Password3"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })

            {

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("businfo@delta.co.zw"), 
                    Subject = "SHE Incident",
                    IsBodyHtml = true,
                    Body = "<h1></h1>",
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };
                var recipients = "h.mupfumi@delta.co.zw;hmupfumi@gmail.com";
                var toAddresses = recipients.Split(';');
                foreach (var to in toAddresses)
                {
                    message.To.Add(to.Trim());
                }

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
