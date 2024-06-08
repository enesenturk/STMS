using NS.STMS.Business.ServiceAdapters.Models.EmailService;

namespace NS.STMS.Business.ServiceAdapters.Adapters.Abstract
{
    public interface IEmailServiceAdapter
	{

		void SendEmail(SendEmailModel sendEmail);

	}
}
