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
   public  class User_Logic:User_Interface
    {
        private User_Interface_DAO userDao = new User_DAO();
        
        public User_Logic()
        {
            this.userDao = new User_DAO(); ;
        }

        public void Add(User value)
        {
            userDao.Add(value);
        }
        public void Update(int id, string pas, string name, DateTime date, int age)
        {
            userDao.UpdateUser(id, pas, name, date, age);
        }
        public void Remove(int id)
        {
            userDao.Remove(id);
        }
        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }
        public IEnumerable<User> GetInfoUser(int id)
        {
            return userDao.GetInfoUser(id);
        }
        public IEnumerable<User> GetAllInfoUser(int id)
        {
            return userDao.GetAllInfoUser(id);
        }
        public int Sign_In(string log, string pas)
        {
            return userDao.Sign_In(log, pas);
        }
        public int Exist_AchievementUser(int id)
        {
            return userDao.Exist_AchievementUser(id);
        }

    }
}
