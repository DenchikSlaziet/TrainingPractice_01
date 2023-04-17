using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04.Models
{
    public abstract class Essence
    {
        public string Name { get; set; }

        private int _hp;
        public int HP
        {
            get { return _hp < 0 ? 0 : _hp; }
            set { _hp = value; }
        }
        public bool IsDeath => HP <= 0;

        public Essence (string name,int hp)
        {
            Name = name;
            HP = hp;
        } 
    }
}
