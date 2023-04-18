using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_06
{
    public class Synopsis
    {
        public string[] FIO { get; set; }
        public string[] Position { get; set; }

        public Synopsis()
        {
            FIO = new string[4] { "Кочетков Денис Александрович","Коршикова Эльвина Павловна",
            "Бажин Кирилл Андреевич","Малышева Александра Викторовна"};
            Position = new string[4] { "Директор", "Главный Бухгалтер", "Менеджер", "Дизайнер" };
        }

        public void AddSynopsis(string FIO, string position)
        {
            if (this.FIO.Where(x => x != FIO).Count() > 0)
            {
                Console.WriteLine("Такой пользователь уже существует!");
            }
            else
            {
                this.FIO = this.FIO.Append(FIO).ToArray();
                Position = Position.Append(position).ToArray();
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("         ФИО\t                           Должность\n");
            for (int i = 0; i < Position.Length; i++)
            {
                Console.WriteLine("{0,-40} {1}", FIO[i], Position[i]);
            }
        }

        public void SearchSynopsis(string str)
        {
            Console.WriteLine("         ФИО\t                           Должность\n");
            for (int i = 0; i < FIO.Length; i++)
            {
                if (FIO[i].ToLower().Contains(str.ToLower()))
                {
                    Console.WriteLine("{0,-40} {1}", FIO[i], Position[i]);
                }
            }
        }

        public void DeleteSynopsis(string str)
        {
            for (int i = 0; i < FIO.Length; i++)
            {
                if (FIO[i].ToLower().Contains(str.ToLower()))
                {
                    (FIO[i], FIO[FIO.Length-1]) = (FIO[FIO.Length-1], FIO[i]);
                    (Position[i], Position[Position.Length-1]) = (Position[Position.Length-1],Position[i]);
                    
                    Position = Position.Where(x => x != Position.Last()).ToArray();
                    FIO = FIO.Where(x => x != FIO.Last()).ToArray();
                }
            }
        }

        
    }
}
