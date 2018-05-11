using System.Collections.Generic;
using web_api.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using web_api.Models.Citizen;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapi.Presistance;

namespace web_api.Presistance
{
    public class CitizenRepository
    {
        private string connectionString;

        public CitizenRepository(IConfiguration configuration)
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
        public Citizen Add(Citizen citizen)
        {
            citizen.GuId = System.Guid.NewGuid().ToString();


            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@guid", citizen.GuId);
                ObjParm.Add("@email", citizen.Email);
                ObjParm.Add("@username", citizen.Username);
                ObjParm.Add("@password", citizen.Password);
                ObjParm.Add("@name", citizen.Name);
                ObjParm.Add("@address", citizen.Address);
                ObjParm.Add("@photo_url", citizen.PhotoUrl);
                ObjParm.Add("@is_sponsor_required", citizen.IsSponsorRequired);
                ObjParm.Add("@support_effort_of", citizen.SupportEfforOf);
                ObjParm.Add("@sponsor_student", citizen.SponsorStudent);
                ObjParm.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("insert_citizens", ObjParm, commandType: CommandType.StoredProcedure);
                citizen.Id = ObjParm.Get<int>("@id");
            }
            return citizen;
        }

        public Citizen Get(string guId)
        {
            var citizen = new Citizen();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT * FROM Citizens WHERE guid = '{guId}'";
                citizen = dbConnection.Query<Citizen>(query).FirstOrDefault();
            }

            return citizen;
        }

        public Citizen UserValidation(LoginPresistance login)
        {
            var citizen = new Citizen();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT * FROM UsersIdentity WHERE username = '{login.Username}' and password = '{login.Password}'";
                User user = dbConnection.Query<User>(query).FirstOrDefault();
                if(user != null){
                    citizen = Get(user.GuId);
                }
            }

            return citizen;
        }

        public List<Citizen> GetAll()
        {
            var list = new List<Citizen>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "SELECT * FROM Citizens";
                list = dbConnection.Query<Citizen>(query).ToList();
            }
            return list;
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "DELETE FROM Citizens WHERE id = @id";
                dbConnection.Execute(query, id);
            }
        }
    }
}