//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        private Purchasing Purch;
        private int coinIndex;

        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        public CoinInserter(int CoinNum, Purchasing Pur)
        {
            Purch = Pur;
            coinIndex = CoinNum;
        }
        public void CoinInserted()
        {
            // You can add only one line here
            Purch.IncreaseTotal(coinIndex);
        }

    }

    public class PurchaseButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        private Purchasing Purch;
        int canIndex;

        public PurchaseButton(int canN, Purchasing Pur)
        {
            canIndex = canN;
            Purch = Pur;
        }
        public void ButtonPressed()
        {
            // You can add only one line here
            Purch.PurchaseCan(canIndex);

        }
    }

    public class CoinReturnButton
    {
        // add a field to specify an object that Button Pressed will visit
        private Purchasing Purch;

        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field
        public CoinReturnButton(Purchasing Pur)
        {
            Purch = Pur;
        }
        public void ButtonPressed()
        {
            // You can add only one lines here
            Purch.CoinReturn();

        }
    }
}
