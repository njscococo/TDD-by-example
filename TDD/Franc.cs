using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Franc : Money
    {
        //private String currency;
        public Franc(int amount, String currency) : base(amount, currency)
        {
                        
        }

        public override Money times(int p)
        {
            return new Franc(amount * p, currency);
            //return Money.franc(amount * p);

        }

        //public override string getCurrency()
        //{
        //    return currency;
        //}
        
    }
}
