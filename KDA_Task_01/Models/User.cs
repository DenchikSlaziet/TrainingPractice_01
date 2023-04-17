using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_01.Models
{
    public class User
    {
        public int GoldCount { get; set; }
        public int CristalCount { get; set; }

        public User(int goldcount)
        {
            GoldCount = goldcount;
            CristalCount = 0;
        }
    }
}
