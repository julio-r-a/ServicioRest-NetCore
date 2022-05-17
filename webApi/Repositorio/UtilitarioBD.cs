using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;
using Entidad;
using System.Data;

namespace Repositorio
{
    public class UtilitarioBD
    {
        public readonly string connectionString = string.Empty;
        private readonly IDbConnection connection;
        public UtilitarioBD()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            connectionString = root.GetSection("ConnectionStrings").GetSection("sql").Value;

            var con = new SqlConnectionStringBuilder(connectionString);
            connection = new SqlConnection(con.ConnectionString);
        }

        public string ObtenerConnectionString
        {
            get => connectionString;
        }


        public IDbConnection Connection
        {
            get => connection;
        }
    }
}

        