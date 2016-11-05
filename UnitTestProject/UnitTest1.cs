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
            TDD.Dollar five = new TDD.Dollar(5);
            Dollar product = five.times(2);
            Assert.AreEqual(new Dollar(10), product);
            product = five.times(3);
            Assert.AreEqual(new Dollar(15), product);
        }

        [TestMethod]
        public void testObjectEquality()
        {            
            //Assert.AreEqual(new Dollar(5), new Dollar(5));
            //Assert.IsTrue(new Dollar(5)(new Dollar(5)));
            //Assert.IsFalse(new Dollar(5).equals(new Dollar(6)));
            AssertHelper.HasSameFieldValues(new Dollar(5), new Dollar(10));

        }
    }

    public class AssertHelper
    {
        public static void HasSameFieldValues<T>(T expected, T actual)
        {
            var notEqual = new List<String>();

            var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | BindingFlags.Instance);
            fields.ToList().ForEach(delegate(FieldInfo field) {
                if(!field.GetValue(expected).Equals(field.GetValue(actual))){
                    notEqual.Add(String.Format("{0}: Expected: <{1}>,  Actual:<{2}>", field.Name, field.GetValue(expected), field.GetValue(actual)));
                }                                                
            });

            if(notEqual.Count>0){
                Assert.Fail("AssertHelper.HasEqualFieldValues failed." + Environment.NewLine + string.Join(Environment.NewLine, notEqual));
            }
        }
    }
}
