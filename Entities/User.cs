using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime Date_Of_Birthday { get; set; }
        public int Age { get; set; }
        public User() { }

        public User( string login, string pas, string name, DateTime date, int age)
        {
            Login = login;
            Password = pas;
            Name = name;
            Date_Of_Birthday = date;
            Age = age;
        }
        public override string ToString()
        {
            return $"{ID}) Name: {Name}";
        }

    }
}

