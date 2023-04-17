using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод слов осуществляется до момента написания слова exit\nВводите любые слова");
            while(!IsCorrectEntry)
            {
                Console.Write("Введенное слово некорректно!\nПовторите ввод: ");
            }
            Console.WriteLine("Правильный ввод");
            Console.ReadLine();
        }

        public static bool IsCorrectEntry => Console.ReadLine().ToLower() == "exit";
    }
}
