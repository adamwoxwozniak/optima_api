using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Optimo2021.Services
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateCompanyConnection();
        IDbConnection CreateConfigurationConnection();
    }

    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateCompanyConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("CompanyConnectionString"));
        }

        public IDbConnection CreateConfigurationConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("ConfigurationConnectionString"));
        }
    }
}
