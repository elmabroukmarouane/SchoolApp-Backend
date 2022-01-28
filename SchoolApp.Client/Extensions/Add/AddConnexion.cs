using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
// using MySql.Data.MySqlClient;
using Npgsql;
using SchoolApp.Infrastructure.DatabaseContext;

namespace SchoSchoolApp.Client.Extensions.Add;
public static class AddConnexion
{
    public static void AddConnection(this IServiceCollection self, IConfiguration configuration,
        IHostEnvironment env)
    {
        self.AddDbContext<DatabaseContext>(options =>
        {
            switch (configuration.GetSection("ConnectionType").Value)
            {
                case "SQLSERVER":
                    UseSqlServer(SqlServerConnectionStringBuilderFunction("ConnectionStrings", "SqlServer", "SqlServerConnection", "SqlServerDbPassword", configuration), options, configuration, env);
                    break;
                // case "MYSQL":
                //     UseMySql(MySqlConnectionStringBuilderFunction("ConnectionStrings", "MySql", "MySqlConnection", "MySqlDbPassword", configuration), options, configuration, env);
                //     break;
                case "POSTGRESQL":
                    UsePostgreSql(PostgreSqlConnectionStringBuilderFunction("ConnectionStrings", "PostgreSql", "PostgreSqlConnection", "PostgreSqlDbPassword", configuration), options, configuration, env);
                    break;
                case "SQLITE":
                    UseSqlite("SqliteConnection", options, configuration, env);
                    break;
                default:
                    UseSqlServer(SqlServerConnectionStringBuilderFunction("ConnectionStrings", "SqlServer", "SqlServerConnection", "SqlServerDbPassword", configuration), options, configuration, env);
                    break;
            }
        });
        static string SqlServerConnectionStringBuilderFunction(string connectionStringSettingSection, string sectionConnectionSetting, string connectionStringName, string ConnectionConfigPart,
            IConfiguration configuration)
        {
            var builer = new SqlConnectionStringBuilder(
                    configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(connectionStringName).Value
                );
            builer.Password = configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(ConnectionConfigPart).Value;
            return builer.ConnectionString;
        }

        static void UseSqlServer(string connectionString, DbContextOptionsBuilder options,
            IConfiguration configuration, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                options.UseSqlServer(
                            connectionString,
                            options => options.EnableRetryOnFailure()
                        ).EnableSensitiveDataLogging();
            }
            options.UseSqlServer(
                        connectionString,
                        options => options.EnableRetryOnFailure()
                    );
        }

        // static string MySqlConnectionStringBuilderFunction(string connectionStringSettingSection, string sectionConnectionSetting, string connectionStringName, string ConnectionConfigPart,
        //     IConfiguration configuration)
        // {
        //     var builer = new MySqlConnectionStringBuilder(
        //             configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(connectionStringName).Value
        //         );
        //     builer.Password = configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(ConnectionConfigPart).Value;
        //     return builer.ConnectionString;
        // }
        // static void UseMySql(string connectionString, DbContextOptionsBuilder options,
        //     IConfiguration configuration, IHostEnvironment env)
        // {
        //     if (env.IsDevelopment())
        //     {
        //         optionsUseMySQL(
        //                     connectionString,
        //                     options => options.EnableRetryOnFailure()
        //                 ).EnableSensitiveDataLogging();
        //     }
        //     options.UseMySQL(
        //         connectionString,
        //         options => options.EnableRetryOnFailure()
        //         );
        // }

        static string PostgreSqlConnectionStringBuilderFunction(string connectionStringSettingSection, string sectionConnectionSetting, string connectionStringName, string ConnectionConfigPart,
            IConfiguration configuration)
        {
            var builer = new NpgsqlConnectionStringBuilder(
                    configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(connectionStringName).Value
                );
            builer.Password = configuration.GetSection(connectionStringSettingSection).GetSection(sectionConnectionSetting).GetSection(ConnectionConfigPart).Value;
            return builer.ConnectionString;
        }
        static void UsePostgreSql(string connectionString, DbContextOptionsBuilder options,
            IConfiguration configuration, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                options.UseNpgsql(
                            connectionString,
                            options => options.EnableRetryOnFailure()
                        ).EnableSensitiveDataLogging();
            }
            options.UseNpgsql(
                connectionString,
                options => options.EnableRetryOnFailure()
                );
        }

        static void UseSqlite(string connectionString, DbContextOptionsBuilder options,
            IConfiguration configuration, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                options.UseSqlite(
                    configuration.GetConnectionString(connectionString)
                   ).EnableSensitiveDataLogging();
            }
            options.UseSqlite(
                configuration.GetConnectionString(connectionString)
                );
        }
    }
}
