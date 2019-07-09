using BL_Interface;
using DAL;
using DAL_Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Achievement_Logic:Achievement_Interface
    {
        
        private Achievement_Interface_DAO achievementDAO;

        public Achievement_Logic()
        {
            this.achievementDAO = new Achievement_DAO(); 
        }
        public void Add(Achievement value)
        {
            achievementDAO.Add(value);

        }
        public IEnumerable<Achievement> GetAll()
        {
            return achievementDAO.GetAll();

        }
        public void Remove(int id)
        {
            achievementDAO.Remove(id);

        }
        public void Update(int id,  string title)
        {
            achievementDAO.Update(id, title);

        }
        public IEnumerable<Achievement> Find(string title)
        {
            return achievementDAO.Find(title);

        }
        public void AddUserAchievement(int id_user, int id_achievement)
        {
            achievementDAO.AddUserAchievement(id_user, id_achievement);

        }
        public void DeleteUserAchievement(int id_user, int id_achievement)
        {
            achievementDAO.DeleteUserAchievement(id_user, id_achievement);

        }
        public IEnumerable<Achievement> YourAchievement(int id)
        {
            return achievementDAO.YourAchievement(id);

        }
        public int Exist_thisAchievement(string title)
        {
            return achievementDAO.Exist_thisAchievement(title);
        }
    }
}
