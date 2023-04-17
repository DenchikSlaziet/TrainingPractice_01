using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_01.Models
{
    public class Seller
    {
        public User CurrentUser { get; set; }
        public const int PRICE = 10;

        public Seller(User currentUser)
        {
            CurrentUser = currentUser;
        }

        public int GetPrice() => PRICE;

        public void Sell(int countCristal)
        {
            while(CurrentUser.GoldCount-PRICE>=0 && countCristal != 0)
            {
                CurrentUser.GoldCount -= PRICE;
                CurrentUser.CristalCount++;
                countCristal--;
            }

            Console.WriteLine("Продажа успешно выполнена");
            PrintCheck();
        }

        private void PrintCheck()=> Console.WriteLine($"Кол-во золота = {CurrentUser.GoldCount}\nКол-во алмазов = {CurrentUser.CristalCount}\n");
    }
}
