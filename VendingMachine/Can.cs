using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Can
    {
        private int price;
        private int amount;
        private Light purchaseLt;
        private Light soldOutLt;
        private CanDispenser canD;

        /// <summary>
        /// the constructor for the can
        /// </summary>
        /// <param name="pri">price of the can</param>
        /// <param name="am">amount of cans</param>
        /// <param name="purLt">the light indicating if the can is purchasable</param>
        /// <param name="solLt">the light indicating if the can is sold out</param>
        /// <param name="CD">the can dispenser for the can</param>
        public Can(int pri, int am, Light purLt, Light solLt, CanDispenser CD)
        {
            price = pri;
            amount = am;
            purchaseLt = purLt;
            soldOutLt = solLt;
            canD = CD;
        }

        /// <summary>
        /// resets the number of cans
        /// </summary>
        /// <param name="amo">the number of cans</param>
        public void ResetData(int amo)
        {
            amount = amo;
            soldOutLt.TurnOff();
        }

        /// <summary>
        /// Turns on and off purchasable lights
        /// </summary>
        /// <param name="money">the money in the machine</param>
        public void PurLights(int money)
        {
            if (price <= money && amount > 0)
            {
                purchaseLt.TurnOn();
            }
            else
            {
                purchaseLt.TurnOff();
            }
        }

        /// <summary>
        /// checks if the can is purchasable
        /// </summary>
        /// <param name="money">the money in the machine</param>
        /// <returns></returns>
        public bool Purchasable(int money)
        {
            if (price > money || amount <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// returns the number of coins left
        /// </summary>
        /// <returns>the number of coins left</returns>
        public int ReturnCansLeft()
        {
            return amount;
        }

        /// <summary>
        /// reduces the number of cans
        /// </summary>
        public int ReduceCan()
        {
            amount--;
            if(amount <= 0) { soldOutLt.TurnOn(); }
            canD.Actuate();
            return price;
        }
    }
}
