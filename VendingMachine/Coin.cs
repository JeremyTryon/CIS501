using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coin
    {
        private int value;
        private int amount;
        private CoinDispenser coinD;

        /// <summary>
        /// the constructor for each coin
        /// </summary>
        /// <param name="val">the value of the coin</param>
        /// <param name="am">the number of coins in the machine</param>
        /// <param name="CD">the coin dispenser</param>
        public Coin(int val, int am, CoinDispenser CD)
        {
            value = val;
            amount = am;
            coinD = CD;
        }

        /// <summary>
        /// resets the data for the coin
        /// </summary>
        /// <param name="amo">the number of coins in the machine</param>
        public void ResetData(int amo)
        {
            amount = amo;
        }

        /// <summary>
        /// increases the number of coins when a coin is inserted
        /// </summary>
        /// <returns>the value of the coin</returns>
        public int InsertCoin()
        {
            amount++;
            return value;          
        }
        
        /// <summary>
        /// returns that number of coins
        /// </summary>
        /// <returns>the number of coins</returns>
        public int AmountOfCoins()
        {
            return amount;
        }

        /// <summary>
        /// reduces the number of coins
        /// </summary>
        /// <param name="money">the money in the machine</param>
        /// <returns>the money returned</returns>
        public int ReduceCoins(int money)
        {
            int x = Convert.ToInt32(Math.Floor(Convert.ToDecimal(money / value))); //calculates the number of coin going to be returned
            int counter = 0;
            while(x > 0 && amount > 0)
            {
                amount--;
                counter++;
                x--;
            }

            coinD.Actuate(counter);
            return counter * value;
        }
    }
}
