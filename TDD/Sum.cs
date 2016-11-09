using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Sum :Expression
    {
        public Money addend;
        public Money augend;

        public Sum(Money augend, Money addend)
        {
            this.addend = addend;
            this.augend = augend;
        }

        public Money reduce(string currency)
        {
            int amount = augend.amount + addend.amount;
            return new Money(amount, currency);
        }
    }
}
