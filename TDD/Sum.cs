using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Sum :Expression
    {
        public Expression addend;
        public Expression augend;

        public Sum(Expression augend, Expression addend)
        {
            this.addend = addend;
            this.augend = augend;
        }

        public Money reduce(Bank bank, string currencyTo)
        {
            int amount = augend.reduce(bank, currencyTo ).amount + addend.reduce(bank, currencyTo).amount;
            return new Money(amount, currencyTo);
        }


        public Expression plus(Expression addend)
        {
            return null;
        }
    }
}
