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
    public class Achievement_DAO: Achievement_Interface_DAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        public void Add(Achievement value)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addAchievement";
                cmd.Parameters.AddWithValue(@"Title", value.Title);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Achievement> GetAll()
        {
            List<Achievement> achievements = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAchievements";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    achievements.Add(new Achievement
                    {
                        ID = (int)reader["ID_Achievement"],
                        Title = (string)reader["Title"]
                    });
                }
            }
            return achievements;
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoveAchievement";
                cmd.Parameters.AddWithValue(@"id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();

            }

        }

        public void Update(int id, string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAchievement";
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.Parameters.AddWithValue(@"title", title);
                connection.Open();
                var reader = cmd.ExecuteReader();

            }

        }

        public IEnumerable<Achievement> Find(string title)
        { List<Achievement> achievements = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FindAchievement";
                cmd.Parameters.AddWithValue(@"title", title);
               
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    achievements.Add(new Achievement
                    {
                        ID = (int)reader["ID_Achievement"],
                        Title = (string)reader["Title"]
                    });
                }
                

            }
            return achievements;
        }

        public void AddUserAchievement(int id_user, int id_achievement)
        {
            
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addUser_Achievement";
                cmd.Parameters.AddWithValue(@"ID_User", id_user);
                cmd.Parameters.AddWithValue(@"ID_Achievement", id_achievement);
                connection.Open();
                var reader = cmd.ExecuteReader();
            }
            
        }
        public void DeleteUserAchievement(int id_user, int id_achievement)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DelUser_Achievement";
                cmd.Parameters.AddWithValue(@"ID_User", id_user);
                cmd.Parameters.AddWithValue(@"ID_Achievement", id_achievement);
                connection.Open();
                var reader = cmd.ExecuteReader();
            }

        }

        public IEnumerable<Achievement> YourAchievement(int id_user)
        {
           
            List<Achievement> achievements = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "YOUR_Achievement";
                cmd.Parameters.AddWithValue(@"ID_User", id_user);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    achievements.Add(new Achievement
                    {
                        ID = (int)reader["ID_Achievement"],
                        Title = (string)reader["Title"]
                    });
                }
            }
            return achievements;
        }


        public int Exist_thisAchievement(string title)
        {
            int count = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Exist_thisAchievement";
                cmd.Parameters.AddWithValue(@"title", title);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    count = (int)reader["CountAchievement"]; 
                }
            }
            return count;
        }
    }
}
