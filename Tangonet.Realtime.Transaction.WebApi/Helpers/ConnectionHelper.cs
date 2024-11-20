using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json.Linq;

namespace Tangonet.Realtime.Transaction.WebApi.Helpers;

public class ConnectionHelper(ILogger<ConnectionHelper> logger)
{
    private readonly ILogger<ConnectionHelper> _logger = logger;
    private static readonly string RdsSecretName = Environment.GetEnvironmentVariable("RdsSecretName");
    private static readonly string Version = Environment.GetEnvironmentVariable("Version");
    private static readonly string Region = Environment.GetEnvironmentVariable("Region");
    public async Task<string> GetRdsDatabaseConnectionString(
        string databaseName)
    {
        _logger.LogInformation(
            $"Getting RDS database connection string for {databaseName}");

       /* using AmazonSecretsManagerClient secretsManagerClient = new(RegionEndpoint.GetBySystemName(Region));
        GetSecretValueRequest request = new()
        {
            SecretId = RdsSecretName,
            VersionStage = Version,
        };*/
        try
        {
/*            GetSecretValueResponse response = await secretsManagerClient.GetSecretValueAsync(request);
            string secret = response.SecretString;
            JObject secretObject = JObject.Parse(secret);
            string rdsProxyHost = secretObject["rds_proxy_host"].ToString();
            string userName = secretObject["user_name"].ToString();
            string port = secretObject["port"].ToString();
            string password = secretObject["password"].ToString();*/

            //string connectionString = $"Server={rdsProxyHost};Port={port};Database={databaseName};Uid={userName};Pwd={password}";

            string connectionString = $"Server=localhost;Port=3307;Database={databaseName};Uid=tangopay;Pwd=ENA094YTC0rvipc_";

            return connectionString;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                $"Failed to get RDS database connection string for {databaseName} with error {ex.Message}");
            throw;
        }
    }
}
