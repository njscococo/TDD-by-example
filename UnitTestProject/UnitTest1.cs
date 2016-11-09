using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDD;
using System.Reflection;

using System.Linq;



namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.IsTrue(new Money(15, "USD").amountEquals(five.times(3)));

        }

        [TestMethod]
        public void testEquality()
        {            
            Assert.IsFalse(Money.dollar(5).amountEquals(Money.dollar(6)));
            
            Assert.IsFalse(new Money(5, "CHF").amountEquals(new Money(6, "CHF")));

            Assert.IsFalse(new Money(5, "USD").amountEquals(new Money(6, "USD")));
        }

        [TestMethod]
        public void testCurrency()
        {
            Assert.AreEqual("USD", Money.dollar(1).getCurrency());
            Assert.AreEqual("CHF", Money.franc(1).getCurrency());
        }

        [TestMethod]
        public void testSimpleAddition()
        {
            Money five = Money.dollar(5);
            Expression sum = five.plus(five);
            Bank bank = new Bank();            
            Money reduced = bank.reduce(sum, "USD");
            Assert.IsTrue(Money.dollar(10).amountEquals(reduced));
        }

        [TestMethod]
        public void testPlusReturnSum()
        {
            Money five = Money.dollar(5);
            Expression result = five.plus(five);
            Sum sum = result as Sum;
            Assert.IsTrue(five.amountEquals(sum.augend));
            Assert.IsTrue(five.amountEquals(sum.addend));
         }

        [TestMethod]
        public void testReduceSum()
        {
            Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
            Bank bank = new Bank();
            Money result = bank.reduce(sum, "USD");
            Assert.IsTrue(Money.dollar(7).amountEquals( result));
        }

        [TestMethod]
        public void testReduceMoney()
        {
            //Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
            Bank bank = new Bank();
            Money result = bank.reduce(Money.dollar(1), "USD");
            Assert.IsTrue(Money.dollar(1).amountEquals(result));
        }
    }

    public class AssertHelper
    {
        //用來判斷2個物件的屬性值是否相同
        public static bool HasSameFieldValues<T>(T expected, T actual)
        {
            var result = true;
            var notEqual = new List<String>();

            var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            fields.ToList().ForEach(delegate(FieldInfo field) {
                if(!field.GetValue(expected).Equals(field.GetValue(actual))){
                    notEqual.Add(String.Format("{0}: Expected: <{1}>,  Actual:<{2}>", field.Name, field.GetValue(expected), field.GetValue(actual)));
                }                                                
            });

            if(notEqual.Count>0){
                result = false;
                //Assert.Fail("AssertHelper.HasEqualFieldValues failed." + Environment.NewLine + string.Join(Environment.NewLine, notEqual));

            }

            return result;
        }


    }
}
