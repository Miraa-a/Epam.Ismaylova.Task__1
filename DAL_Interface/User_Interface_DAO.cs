using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Interface
{
    public interface User_Interface_DAO
    {
        void Add(User value);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetInfoUser(int id);
        void UpdateUser(int id, string pas, string name, DateTime date, int age);
        void Remove(int id);
        IEnumerable<User> GetAllInfoUser(int id);
        int Sign_In(string log, string pas);
        int Exist_AchievementUser(int id);
        

    }
}
