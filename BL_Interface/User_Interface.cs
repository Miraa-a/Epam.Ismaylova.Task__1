using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Interface
{
    public interface User_Interface
    {
        void Add(User value);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetInfoUser(int id);
        void Update(int id, string pas, string name, DateTime date, int age);
        void Remove(int id);
        IEnumerable<User> GetAllInfoUser(int id);
        int Sign_In(string log, string pas);
        int Exist_AchievementUser(int id);
    }
}
