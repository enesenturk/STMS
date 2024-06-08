namespace NS.STMS.Business.ServiceAdapters.Models.EmailService
{
    public class SendEmailModel
    {

        public string ReceiverEmailAddress { get; set; }

        public string Subject { get; set; }
        public string EmailBody { get; set; }

    }
}
