using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public  class Money : Expression
    {
        public  int amount;
        protected String currency;

        public Money(int amount, String currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }


        public bool amountEquals(Object obj)
        {
            Money money = obj as Money;
            return this.amount == money.amount && this.getCurrency()==money.getCurrency();

        }

        public String getCurrency()
        {
            return currency;
        }
        
        public Money times(int multiple)
        {
            return new Money(amount * multiple, currency);
        }


        public Expression plus(Money addend)
        {
            //return new Money(amount + added.amount, currency);
            return new Sum(this, addend);
        }

        public Money reduce(Bank bank, string currencyTo)
        {
            //int rate =  this.currency.Equals("CHF") && currencyTo.Equals("USD") ? 2 : 1;
            int rate = bank.rate(this.currency, currencyTo);
            return new Money(amount / rate, currencyTo);
        }
    }

    public interface Expression
    {
        Money reduce(Bank bank, String currencyTo);
    }
}
