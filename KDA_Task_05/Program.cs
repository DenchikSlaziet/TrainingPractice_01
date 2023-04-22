using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_05
{
    public class Program
    {
        static int SchetHodov = 0;
        static void FieldOutput(int[,] Mas)
        {

            var x = 0;
            var y = 0;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < Mas.GetLength(0); i++, ++y)
            {
                for (int j = 0; j < Mas.GetLength(1); j++, ++x)
                {
                    Console.SetCursorPosition(x, y);
                    if (Mas[i, j] == 1)
                    {
                        Console.Write("▓");
                    }
                }
                x = 0;
            }
        }
        static void StrokeCheck(int[,] Mas, int x, int y, bool Hod)
        {
            if (Hod)
            {
                Console.Clear();
                FieldOutput(Mas);
                Console.SetCursorPosition(x, y);
                Console.Write("☺");
                ++SchetHodov;
                Console.SetCursorPosition(73, 14);
                Console.Write("Ходов: " + SchetHodov);
                Console.SetCursorPosition(0, 27);
            }
            else
            {
                ++SchetHodov;
                Console.Clear();
                FieldOutput(Mas);
                Console.SetCursorPosition(x, y);
                Console.Write("☺");
                Console.SetCursorPosition(73, 14);
                Console.Write("Ходов: " + SchetHodov);
                Console.SetCursorPosition(73, 7);
                Console.Write("Вы уперлись в стену!");
                Console.SetCursorPosition(0, 27);
            }
        }
        static void EventChecking(int[,] Mas, int x, int y, ref bool GameOver, string[] Filosofia)
        {
            Random rand = new Random();
            if (Mas[y, x] == 3)
            {
                Console.SetCursorPosition(73, 7);
                Console.Write("Клетка Боли - вы получили +50 Ходов :(");
                Console.SetCursorPosition(0, 27);
                SchetHodov += 50;
            }

            if (Mas[y, x] == 4)
            {
                Console.SetCursorPosition(73, 7);
                Console.Write("Вы нашли алтарь сброса и он сбросил все ваши ходы :)");
                Console.SetCursorPosition(0, 27);
                SchetHodov = 0;
            }
            if (Mas[y, x] == 5)
            {
                Console.SetCursorPosition(73, 7);
                Console.Write("Анатолий Александрович, вы действительно в это играете???");
                Console.SetCursorPosition(0, 27);
            }

            if (Mas[y, x] == 2)
            {
                GameOver = true;
                Console.SetCursorPosition(73, 7);
                Console.Write("Вы вышли из лабиринта поздравляю!");
                Console.SetCursorPosition(0, 27);
            }
            if (Mas[y, x] == 6)
            {
                Console.SetCursorPosition(63, 7);
                Console.Write("Цитаты Великих людей: " + Filosofia[rand.Next(0, Filosofia.Length)]);
                Console.SetCursorPosition(0, 27);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string[] Filosofia =
        {"Благородно только то, что бескорыстно.  Ж. Лабрюйер ",
            "Доброта лучше красоты.  Г. Гейне",
            "Терпи и воздерживайся.  Эпиктет",
            "Я не люблю сражаться, я люблю побеждать.  Б. Шоу",
            "Слава - товар невыгодный. Стоит дорого, сохраняется плохо.  О. Бальзак",
            "Надо уметь переносить то, чего нельзя избежать.  М. Монтень",
            "Не получить вовсе - не страшно, но лишиться полученного обидно.  Клавдий Элиан",
            "Все приходит вовремя, если люди умеют ждать.  Ф. Рабле",
            "Бедность указывает на отсутствие средств, а не на отсутствие благородства.  Д. Боккаччо"
            };

            int[,] Mas = new int[17, 55];
            using (var fw = new StreamReader("Maze.txt", System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < Mas.GetLength(0); i++)
                {
                    var str = fw.ReadLine();
                    for (int j = 0; j < Mas.GetLength(1); j++)
                    {
                        Mas[i, j] = (int)Char.GetNumericValue(str[j]);
                    }
                }
            }

            FieldOutput(Mas);
            Console.SetCursorPosition(80, 5);
            Console.Write("Добро пожаловать в игру Лабиринт!");
            Console.SetCursorPosition(67, 6);
            Console.Write("Вам нужно добраться до Выхода.");
            Console.SetCursorPosition(73, 7);
            Console.Write("Лабиринт таит в себе тайны, вдруг вы их найдете");
            Console.SetCursorPosition(73, 9);
            Console.Write("w - Вверх   s - Вниз   d - Вправо    a - Влево");
            Console.SetCursorPosition(81, 10);
            Console.Write("Для удобства увеличьте консоль!!");
            var x = 1;
            var y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☺");
            var GameOver = false;
            while (!GameOver)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (Mas[--y, x] == 1)
                        {
                            ++y;
                            StrokeCheck(Mas, x, y, false);
                        }
                        else
                        {
                            StrokeCheck(Mas, x, y, true);
                            EventChecking(Mas, x, y, ref GameOver, Filosofia);
                        }
                        break;

                    case ('s'):
                        if (Mas[++y, x] == 1)
                        {
                            --y;
                            StrokeCheck(Mas, x, y, false);
                        }
                        else
                        {
                            StrokeCheck(Mas, x, y, true);
                            EventChecking(Mas, x, y, ref GameOver, Filosofia);
                        }
                        break;

                    case ('a'):
                        if (Mas[y, --x] == 1)
                        {
                            ++x;
                            StrokeCheck(Mas, x, y, false);
                        }
                        else
                        {
                            StrokeCheck(Mas, x, y, true);
                            EventChecking(Mas, x, y, ref GameOver, Filosofia);
                        }
                        break;

                    case ('d'):
                        if (Mas[y, ++x] == 1)
                        {
                            --x;
                            StrokeCheck(Mas, x, y, false);
                        }
                        else
                        {
                            StrokeCheck(Mas, x, y, true);
                            EventChecking(Mas, x, y, ref GameOver, Filosofia);
                        }
                        break;
                    default:
                        Console.Clear();
                        FieldOutput(Mas);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☺");
                        Console.SetCursorPosition(73, 7);
                        Console.Write("Еще раз напоминаю (w - Вверх   s - Вниз   d - Вправо    a - Влево)");
                        Console.SetCursorPosition(0, 27);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
