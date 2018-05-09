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
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@name", memorization.Name);
                ObjParm.Add("@is_completed", memorization.IsCompleted);
                ObjParm.Add("@ayat_from", memorization.From);
                ObjParm.Add("@ayat_to", memorization.To);
                ObjParm.Add("@updated_date", memorization.UpdatedDate);
                ObjParm.Add("@user_guid", memorization.UserGuId);
                
                dbConnection.Execute("Insert_Memorization", ObjParm, commandType: CommandType.StoredProcedure);
                memorization.Id = ObjParm.Get<int>("@id");
                // return dbConnection.Query<Citizen>(query, citizen).FirstOrDefault();
            }
            return memorization;
        }
    }
}