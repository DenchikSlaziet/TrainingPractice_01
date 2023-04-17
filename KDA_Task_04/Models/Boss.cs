using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04.Models
{
    public class Boss:Essence
    {
        public int Damage => new Random().Next(0, 100);

        public Boss(string name,int hp) : base(name, hp) { }
    }
}
