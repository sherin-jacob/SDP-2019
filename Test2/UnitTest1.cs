using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2.Persistence;
using Xamarin.Forms;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var database = DependencyService.Get<>
            Assert.IsTrue(1 == 1, "True");
        }
    }
}
