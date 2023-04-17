using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_03
{
    internal class Program
    {
        private const string PASSWORD = "1234Denis";

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите пароль: ");

                if(Console.ReadLine()==PASSWORD)
                {
                    Console.WriteLine("Пароли совпадают!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Пароль неверный!");
            }

            Console.WriteLine("Вы исчерпали все попытки");
            Console.ReadLine();
        }
    }
}
