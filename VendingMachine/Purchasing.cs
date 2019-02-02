using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Purchasing
    {
        private Can[] cans; 
        private Coin[] coins; 
        private int _totalEntered; 
        private AmountDisplay amountD;
        private TimerLight timerL;

        /// <summary>
        /// constructor for purchasing 
        /// </summary>
        /// <param name="canArr">the array of cans</param>
        /// <param name="coinArr">the array of coins</param>
        /// <param name="changeLight">the no change light</param>
        /// <param name="AmoD">the display for the money in the machine</param>
        public Purchasing(Can[] canArr, Coin[] coinArr, TimerLight changeLight, AmountDisplay AmoD)
        {
            _totalEntered = 0;
            cans = canArr;
            coins = coinArr;
            timerL = changeLight;
            amountD = AmoD;
        }

        /// <summary>
        /// resets the machines data for when it is refilled
        /// </summary>
        /// <param name="canArr">the array of cans</param>
        /// <param name="coinArr">the array of coins</param>
        public void ResetData(Can[] canArr, Coin[] coinArr)
        {
            cans = canArr;
            coins = coinArr;
            _totalEntered = 0;
            amountD.DisplayAmount(_totalEntered);
            LightUpCans();
        }

        /// <summary>
        /// increases the money in the machine by the coin entered and lights up the correct buttons
        /// </summary>
        /// <param name="coNum">the index indicating a coin in the array</param>
        public void IncreaseTotal(int coNum)
        {
            _totalEntered += coins[coNum].InsertCoin();
            amountD.DisplayAmount(_totalEntered);

            LightUpCans();
        }

        /// <summary>
        /// returns all of the coins in the machine and updates the lights
        /// </summary>
        public void CoinReturn()
        {
            if (_totalEntered > 0)
            {
                for (int i = coins.Length - 1; i >= 0; i--)
                {
                    _totalEntered -= coins[i].ReduceCoins(_totalEntered);
                }               
            }
            amountD.DisplayAmount(_totalEntered);
            LightUpCans();
            timerL.TurnOn3Sec();
        }

        /// <summary>
        /// updates all of the can light and turns them on or off depending on the amount entered
        /// </summary>
        private void LightUpCans()
        {
            for (int i = 0; i < cans.Length; i++)
            {
                cans[i].PurLights(_totalEntered);
            }
        }

        /// <summary>
        /// purchases a can
        /// </summary>
        /// <param name="canNum">an index relating to which can button was pressed</param>
        public void PurchaseCan(int canNum)
        {
            if (!cans[canNum].Purchasable(_totalEntered)) { return; }
            
            _totalEntered -= cans[canNum].ReduceCan();
            CoinReturn();
        }

    }
}
