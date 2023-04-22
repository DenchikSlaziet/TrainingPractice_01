using KDA_Task_04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boss = new Boss(GetParseString("для босса"),300);
            var player = new Player(GetParseString("для героя"),500);
            Spell spell = null;
            while(!player.IsDeath && !boss.IsDeath)
            {            
                switch (GetParseInt())
                {
                    case 1:
                        spell = new Ramashon();
                        Console.WriteLine("Вы призываете темного духа!");
                        break;

                    case 2:
                        spell = new Huganzakura();
                        if(player.IsRamashon)
                        {
                            Console.WriteLine($"Вы наносите {spell.Damage} урона");
                        }
                        else
                        {
                            Console.WriteLine("Темный дух еще не призван!");
                        }
                        break;

                    case 3:
                        spell = new Dimensional();
                        Console.WriteLine($"Вы востанавливаете {spell.Health} HP");
                        break;
                    case 4:
                        spell = new Kick();
                        Console.WriteLine($"Вы наносите {spell.Damage} урона");
                        break;
                    default:
                        Console.WriteLine("Такого заклинания нет");
                        break;
                }

                var round = new Round(boss, player, spell);
                var resultRound = round.Fight();
                boss = resultRound.Item2;
                player = resultRound.Item1;

                Console.WriteLine($"{boss.Name}: {boss.HP} HP\n{player.Name}: {player.HP} HP\n");
            }

            if (player.IsDeath)
            {
                Console.WriteLine($"К сожалению {player.Name} проиграл боссу по имени {boss.Name}");
            }
            else
            {
                Console.WriteLine($"{player.Name} смог победить босса по имени {boss.Name}");
            }

            Console.ReadLine();
        }

       public static int GetParseInt()
       {
            while(true)
            {
                Console.WriteLine("Выбирите заклинание\n" +
                   "1.Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)\n" +
                   "2.Хуганзакура (Может быть выполнен только после призыва теневого духа), наносит 100 ед. урона\n" +
                   "3.Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп. Урон босса по вам не проходит\n"+
                   "4.Удар – Наносит 100 урона\n");

                if (Int32.TryParse(Console.ReadLine(), out int value) && value<4 && value>0)
                {
                    return value;
                }

                Console.WriteLine("Используйте существующее заклинание");
            }
       }

        public static string GetParseString(string str)
        {
            while (true)
            {
                Console.Write($"Введите имя {str}: ");
                var name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                Console.WriteLine("Имя не может быть пустое");
            }
        }
    }
}
