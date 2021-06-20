using System.Data.Common;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Data.Repositories
{
    public abstract class BaseDbConnectionManager : IDbConnectionManager
    {
        private readonly IConfiguration _config;
        protected virtual string ConnectionString => "DefaultConnection";
        public virtual DbConnection GetDbConnection => new NpgsqlConnection(_config.GetConnectionString(ConnectionString));

        protected BaseDbConnectionManager(IConfiguration config)
        {
            _config = config;
        }
    }

    public interface IDbConnectionManager
    {
    }
}