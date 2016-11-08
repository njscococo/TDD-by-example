﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Dollar : Money
    {
        //private String currency;

        public Dollar(int amount, String currency) :base(amount,currency)
        {
           
        }

        public override Money times(int p)
        {
            //return Money.dollar(amount * p);
            return new Dollar(amount * p, currency);
        }

        //public override string getCurrency()
        //{
        //    return currency;
        //}
    }
}
