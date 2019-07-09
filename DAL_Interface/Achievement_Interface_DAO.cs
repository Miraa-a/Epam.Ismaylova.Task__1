using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Interface
{
    public interface Achievement_Interface_DAO
    {
        void Add(Achievement value);
        IEnumerable<Achievement> GetAll();
        void Remove(int id);
        void Update(int id, string title);
        IEnumerable<Achievement> Find(string title);
        void AddUserAchievement(int id_user, int id_achievement);
        void DeleteUserAchievement(int id_user, int id_achievement);
        IEnumerable<Achievement> YourAchievement(int id_user);
        int Exist_thisAchievement(string title);
    }
}
