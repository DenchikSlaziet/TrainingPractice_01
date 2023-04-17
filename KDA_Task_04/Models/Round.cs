using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04.Models
{
    public class Round
    {
        public Boss Boss { get; set; }
        public Player Player { get; set; }
        public Spell Spell { get; set; }

        public Round(Boss boss,Player player, Spell spell)
        {
            Boss = boss;
            Player = player;
            Spell = spell;
        }

        public (Player,Boss) Fight()
        {
            Player.HP += Spell.Health;
            if (!(Spell is Dimensional))
            {
                Player.HP -= Boss.Damage;
            }

            if (Spell is Huganzakura)
            {
                if (Player.IsRamashon)
                {
                    Boss.HP -= Spell.Damage;
                    Player.IsRamashon = false;
                }
                return (Player, Boss);
            }

            Player.IsRamashon = Spell is Ramashon;
            Boss.HP -= Spell.Damage;
            return (Player,Boss);
        }
    }
}
