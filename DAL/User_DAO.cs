using DAL_Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User_DAO : User_Interface_DAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        public void Add(User value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addUser";
                cmd.Parameters.AddWithValue(@"Login", value.Login);
                cmd.Parameters.AddWithValue(@"Password", value.Password);
                cmd.Parameters.AddWithValue(@"Name", value.Name);
                cmd.Parameters.AddWithValue(@"Date", value.Date_Of_Birthday);
                cmd.Parameters.AddWithValue(@"Age", value.Age);
                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID_User",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetListUser";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = (int)reader["ID_User"],
                        Name = (string)reader["Name"],
                    });
                }
            }
            return users;
        }
        public IEnumerable<User> GetInfoUser(int id)
        {
            List<User> users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetINFO_User";
                cmd.Parameters.AddWithValue(@"ID_User", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = (int)reader["ID_User"],
                        Name = (string)reader["Name"],
                        Date_Of_Birthday = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    });
                }
            }
            return users;
        }

        public void UpdateUser(int id, string pas, string name, DateTime date, int age)
        {
           // List<User> users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";
                cmd.Parameters.AddWithValue(@"id_user", id);
               
                cmd.Parameters.AddWithValue(@"Password", pas);
                cmd.Parameters.AddWithValue(@"Name", name);
                cmd.Parameters.AddWithValue(@"DateOfBirth", date);
                cmd.Parameters.AddWithValue(@"Age", age);
                connection.Open();
                var reader = cmd.ExecuteReader();
                
            }
           // return users;
        }
        public void Remove(int id)
        {
            // List<User> users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoveUser";
                cmd.Parameters.AddWithValue(@"id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();

            }
            
        }
        public IEnumerable<User> GetAllInfoUser(int id)
        {
            List<User> users = new List<User>();
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetALL_INFO_User";
                cmd.Parameters.AddWithValue(@"ID_User", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ID = (int)reader["ID_User"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Name = (string)reader["Name"],
                        Date_Of_Birthday = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["Age"]
                    });
                }
            }
            return users;
        }
        public int Sign_In(string log, string pas)
        {
            int ID = -1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginUser";
                cmd.Parameters.AddWithValue(@"Login", log);
                cmd.Parameters.AddWithValue(@"Password", pas);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = (int)reader["ID_User"];

                }

            }
            return ID;
        }
        public int Exist_AchievementUser (int id)
        {
            int count = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Exist_AchivementUser";
                cmd.Parameters.AddWithValue(@"ID_User", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = (int)reader["AchivementUser"];

                }

            }
            return count;
        }
    }
}
