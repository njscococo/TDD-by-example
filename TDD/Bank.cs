using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD;

namespace TDD
{
    public class Bank
    {
        public TDD.Money reduce(TDD.Expression source, string currency)
        {
            if (source.GetType().Name == "Money") return (source as Money).reduce(currency);

            Sum sum = source as Sum;
            //int amount = sum.augend.amount + sum.addend.amount;
            return sum.reduce(currency);
        }
    }
}
