using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Achievement
    {
        public Achievement()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; }

        public Achievement(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{ID}. {Title}";
        }
    }
}
