using NS.STMS.Business.ServiceAdapters.Adapters.Abstract;
using System.Net.Mail;
using System.Net;
using NS.STMS.Settings;
using NS.STMS.Business.ServiceAdapters.Models.EmailService;

namespace NS.STMS.Business.ServiceAdapters.Adapters.Concrete.DotNetAdapters
{

    public class DotNetEmailServiceAdapter : IEmailServiceAdapter
	{

		public void SendEmail(SendEmailModel sendEmail)
		{
			try
			{
				MailMessage mail = new MailMessage(AppSettings.SenderEmailAddress, sendEmail.ReceiverEmailAddress, sendEmail.Subject, sendEmail.EmailBody);

				mail.IsBodyHtml = true;

				SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
				{
					Port = 587,
					Credentials = new NetworkCredential(AppSettings.SenderEmailAddress, AppSettings.SenderEmailPassword),
					EnableSsl = true,
					UseDefaultCredentials = false,
					DeliveryMethod = SmtpDeliveryMethod.Network
				};

				smtpClient.Send(mail);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

	}
}
