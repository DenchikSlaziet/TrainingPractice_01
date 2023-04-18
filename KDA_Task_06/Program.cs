using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_06
{
    public class Program
    {
        static void Main(string[] args)
        {
            var synopsis = new Synopsis();

            while (true)
            {
                Console.WriteLine("Выбирите операцию:");
                Console.WriteLine("1 - Добавить досье\n2 - Вывести все досье\n3 - Удалить досье\n" +
                    "4 - Поиск по фамилии\n5 - Выход\n");
                switch (GetParseInt("операцию"))
                {
                    case 1:
                        var fio = GetParseString("ФИО");
                        var position = GetParseString("должность");
                        synopsis.AddSynopsis(fio, position);
                        break;
                    case 2:
                        synopsis.PrintAll();
                        break;
                    case 3:
                        {
                            var str = GetParseString("фамилию пользователя");
                            synopsis.DeleteSynopsis(str);
                            break;
                        }
                    case 4:
                        {
                            var str = GetParseString("фамилию пользователя");
                            synopsis.SearchSynopsis(str);
                            break;
                        }
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Такого дей-ия нет!");
                        break;
                }
                Console.WriteLine();
            }
        }

        public static int GetParseInt(string str)
        {
            while (true)
            {
                Console.Write("Введите " + str + ": ");
                if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Ввод некорректный!");
            }
        }

        public static string GetParseString(string str)
        {
            while (true)
            {
                Console.Write($"Введите {str}: ");
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
