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
            Assert.IsTrue(new Dollar(15, "USD").amountEquals(five.times(3)));

        }

        [TestMethod]
        public void testFrancMultiplication()
        {
            Money five = Money.franc(5);
            Assert.IsTrue(new Franc(25, "CHF").amountEquals(five.times(5)));

        }

        [TestMethod]
        public void testEquality()
        {
            Assert.IsTrue(Money.dollar(5).amountEquals(Money.dollar(5)));
            Assert.IsFalse(Money.dollar(5).amountEquals(Money.dollar(6)));

            Assert.IsTrue(new Franc(5, "CHF").amountEquals(new Franc(5,"CHF")));
            Assert.IsFalse(new Franc(5, "CHF").amountEquals(new Franc(6, "CHF")));
            //Assert.IsTrue(AssertHelper.HasSameFieldValues(new Dollar(10), new Dollar(10)));
            //Assert.IsFalse( AssertHelper.HasSameFieldValues(new Dollar(15), new Dollar(16)));

            Assert.IsFalse(new Dollar(5, "USD").amountEquals(new Franc(5, "CHF")));
            Assert.IsFalse(new Dollar(5, "USD").amountEquals(new Dollar(6, "USD")));
        }

        [TestMethod]
        public void testCurrency()
        {
            Assert.AreEqual("USD", Money.dollar(1).getCurrency());
            Assert.AreEqual("CHF", Money.franc(1).getCurrency());
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
