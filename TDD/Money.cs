using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public abstract class Money
    {
        protected int amount;
        protected String currency;

        public Money(int amount, String currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public bool amountEquals(Object obj)
        {
            Money money = obj as Money;
            return this.amount == money.amount && this.GetType().Name==obj.GetType().Name;
        }

        public String getCurrency()
        {
            return currency;
        }


        public abstract Money times(int multiple);


        public static Money dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Franc(amount, "CHF");
        }




        
    }
}
