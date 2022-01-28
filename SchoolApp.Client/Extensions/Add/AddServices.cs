namespace SchoSchoolApp.Client.Extensions.Add
{
    public static class AddServices
    {
        public static void AddSERVICES(this IServiceCollection self, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            // self.AddTransient<IUnitOfWork<DatabaseContext>, UnitOfWork<DatabaseContext>>();

            // self.AddTransient<IGenericQueryService<Role>, GenericQueryService<Role>>();
            // self.AddTransient<IGenericCommandService<Role>, GenericCommandService<Role>>();
            // self.AddTransient<IGenericQueryService<Group>, GenericQueryService<Group>>();
            // self.AddTransient<IGenericCommandService<Group>, GenericCommandService<Group>>();
            // self.AddTransient<IGenericQueryService<Person>, GenericQueryService<Person>>();
            // self.AddTransient<IGenericCommandService<Person>, GenericCommandService<Person>>();
            // self.AddTransient<IGenericQueryService<User>, GenericQueryService<User>>();
            // self.AddTransient<IGenericCommandService<User>, GenericCommandService<User>>();
            // self.AddTransient<IGenericQueryService<Duration>, GenericQueryService<Duration>>();
            // self.AddTransient<IGenericCommandService<Duration>, GenericCommandService<Duration>>();
            // self.AddTransient<IGenericQueryService<Issue>, GenericQueryService<Issue>>();
            // self.AddTransient<IGenericCommandService<Issue>, GenericCommandService<Issue>>();

            // self.AddTransient<IAuthenticationService, AuthenticationService>();

            // self.AddTransient<ISendMailService, SendMailService>();
            // self.AddTransient<ISmtpClient, SmtpClient>();

            // self.AddTransient<IRealTimeHub, RealTimeHub>();

            self.AddSingleton(configuration);
            self.AddSingleton(hostEnvironment);
        }
    }
}
