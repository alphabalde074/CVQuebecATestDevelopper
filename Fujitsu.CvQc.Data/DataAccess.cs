using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fujitsu.CvQc.Data;
public class DataAccess : IDataAccess
{
    public void ConfigDataContext(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DataContext");

        if (String.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidDataException("connectionString is null or empty");
        }
        else
        {
            connectionString = FormatConnectionString(configuration, connectionString);
        }

        serviceCollection.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                connectionString,
                providerOptions =>
                {
                    providerOptions.EnableRetryOnFailure();
                    providerOptions.MigrationsAssembly("Fujitsu.CvQc.Data");
                    providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                }
            ).LogTo(Console.WriteLine, LogLevel.Information)
        );
    }

    public static string FormatConnectionString(IConfiguration configuration, string connectionString)
    {
        var externalSettingPath = configuration["ExternalSettingPath"];
        if (!String.IsNullOrWhiteSpace(externalSettingPath))
        {
            // Extract missing parameters from external file and replace in connection string 
            //   dataContext.val1: username, 
            //   dataContext.val2: partial password (passowrd ending kept inside the connectionString)
            using (StreamReader reader = new StreamReader(externalSettingPath))
            {
                string json = reader.ReadToEnd();
                dynamic? settings = JsonConvert.DeserializeObject(json);
                if (settings != null)
                {
                    string val1 = settings.dataContext.val1.Value;
                    string val2 = settings.dataContext.val2.Value;

                    if (!string.IsNullOrEmpty(val1))
                    {
                        connectionString = connectionString.Replace("{val1}", val1);
                    }
                    if (!string.IsNullOrEmpty(val2))
                    {
                        connectionString = connectionString.Replace("{val2}", val2);
                    }
                }
                reader.Close();
            }
        }
        else
        {
            // Extract missing parameters from system variables and replace in connection string 

            // TODO: Si externalSettingPath est null, lire val1 et val2 dans les variables d'environment du système à la place (ou autre manière appropriée).
            //         pourrait être nécessaire en production où autre environment sans fichier pour contenir l'utilisateur et le mot de passe de la connection à bd
        }

        return connectionString;
    }
}
