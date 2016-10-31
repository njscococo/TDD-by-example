using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDD;


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
            Assert.IsTrue(new Dollar(5).equals(new Dollar(5)));
            Assert.IsFalse(new Dollar(5).equals(new Dollar(6)));
            
        }
    }
}
