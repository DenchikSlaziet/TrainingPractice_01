using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04.Models
{
    public class Player:Essence
    {      
        public bool IsRamashon { get; set; }

        public Player(string name,int hp):base(name,hp)
        {
            IsRamashon = false;
        }
    }
}
