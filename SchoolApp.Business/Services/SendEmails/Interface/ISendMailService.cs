using SchoolApp.Business.Services.SendEmails.Models.Classes;

namespace SchoolApp.Business.Services.SendEmails.Interface;
public interface ISendMailService
{
    Task Send(EmailMessage emailMessage, EmailConfiguration emailConfiguration);
}
