using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04.Models
{
    public class Player
    {
        public string Name { get; set; }

        private int _hp;
        public int HP
        {
            get { return _hp < 0 ? 0 : _hp; }
            set { _hp = value; }
        }
        public bool IsRamashon { get; set; }
        public bool IsDeath => HP <= 0;

        public Player(string name)
        {
            Name = name;
            HP = 300;
            IsRamashon = false;
        }
    }
}
