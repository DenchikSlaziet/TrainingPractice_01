using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDA_Task_01.Models
{
    public class SellContrller
    {
        public User CurrentUser { get; set; }
        public const int PRICE = 10;
        public int CountCristal { get; set; }
        public bool IsGood => PRICE * CountCristal <= CurrentUser.GoldCount;

        public SellContrller(User currentUser,int countcristal)
        {
            CurrentUser = currentUser;
            CountCristal = countcristal;
        }

        public int GetPrice() => PRICE;

        public void Sell()
        {
            if (IsGood)
            {
                CurrentUser.CristalCount+=CountCristal;
                CurrentUser.GoldCount-= CountCristal * PRICE;
            }
            PrintCheck();
        }

        private void PrintCheck()=> Console.WriteLine($"Кол-во золота = {CurrentUser.GoldCount}\nКол-во алмазов = {CurrentUser.CristalCount}\n");
    }
}
