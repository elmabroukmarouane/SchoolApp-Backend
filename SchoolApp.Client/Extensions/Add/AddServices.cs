using MailKit.Net.Smtp;
using SchoolApp.Business.Services.Authentication.Classe;
using SchoolApp.Business.Services.Authentication.Interface;
using SchoolApp.Business.Services.Commands.Classes;
using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Business.Services.Queries.Classes;
using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Business.Services.SendEmails.Classe;
using SchoolApp.Business.Services.SendEmails.Interface;
using SchoolApp.Client.RealTime.Hubs.Classe;
using SchoolApp.Client.RealTime.Hubs.Interface;
using SchoolApp.Infrastructure.DatabaseContext;
using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.UnitOfWork.UnitOfWork.Classe;
using SchoolApp.UnitOfWork.UnitOfWork.Interface;

namespace SchoSchoolApp.Client.Extensions.Add;
public static class AddServices
{
    public static void AddSERVICES(this IServiceCollection self, IConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        self.AddTransient<IUnitOfWork<DatabaseContextSchool>, UnitOfWork<DatabaseContextSchool>>();

        self.AddTransient<IGenericQueryService<Role>, GenericQueryService<Role>>();
        self.AddTransient<IGenericCommandService<Role>, GenericCommandService<Role>>();
        self.AddTransient<IGenericQueryService<Person>, GenericQueryService<Person>>();
        self.AddTransient<IGenericCommandService<Person>, GenericCommandService<Person>>();
        self.AddTransient<IGenericQueryService<User>, GenericQueryService<User>>();
        self.AddTransient<IGenericCommandService<User>, GenericCommandService<User>>();
        self.AddTransient<IGenericQueryService<Level>, GenericQueryService<Level>>();
        self.AddTransient<IGenericCommandService<Level>, GenericCommandService<Level>>();
        self.AddTransient<IGenericQueryService<Course>, GenericQueryService<Course>>();
        self.AddTransient<IGenericCommandService<Course>, GenericCommandService<Course>>();
        self.AddTransient<IGenericQueryService<Professor>, GenericQueryService<Professor>>();
        self.AddTransient<IGenericCommandService<Professor>, GenericCommandService<Professor>>();
        self.AddTransient<IGenericQueryService<Student>, GenericQueryService<Student>>();
        self.AddTransient<IGenericCommandService<Student>, GenericCommandService<Student>>();

        self.AddTransient<IAuthenticationService, AuthenticationService>();

        self.AddTransient<ISendMailService, SendMailService>();
        self.AddTransient<ISmtpClient, SmtpClient>();

        self.AddTransient<IRealTimeHub, RealTimeHub>();

        self.AddSingleton(configuration);
        self.AddSingleton(hostEnvironment);
    }
}
