using KDA_Task_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User(GetParseInt("кол-во золота"));
            Console.WriteLine($"Курс\n1 кристал = 10 золотых");
            var count = GetParseInt("желаемое кол-во кристалов");
            var seller = new SellContrller(user, count);
            seller.Sell();
            Console.ReadLine();

        }
        public static int GetParseInt(string str)
        {
            int value;

            Console.Write("Введите " + str + ": ");
            while (!(Int32.TryParse(Console.ReadLine(), out value) && value > 0))
            {
                Console.WriteLine("Неверный формат!");
                Console.Write("Введите " + str + ": ");
            }

            return value;
        }
    }
}
