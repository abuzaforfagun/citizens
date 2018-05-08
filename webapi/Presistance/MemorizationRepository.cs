using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using web_api.Models;

namespace web_api.Presistance
{
    public class MemorizationRepository
    {
        private string connectionString;
        
        public MemorizationRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Production");

        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        
        public Memorization Add(Memorization memorization)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query =
                $@"exec Insert_Memorization 
                {memorization.Id}, 
                '{memorization.Name}', 
                {memorization.From}, 
                {memorization.To}, 
                '{memorization.UpdatedDate}', 
                '{memorization.UserGuId}'
                ";
                // dbConnection.Execute(query);
                dbConnection.Query<int>(query, memorization.Id);
                // return dbConnection.Query<Citizen>(query, citizen).FirstOrDefault();
            }
            return memorization;
        }
    }
}