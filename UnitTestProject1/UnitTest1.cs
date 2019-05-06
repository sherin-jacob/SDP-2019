using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
using Xamarin.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            private INavigation nav;
           var vm = new ItineraryViewModel(INavigation _nav);
            int a = 5;
            int b = 5;
            Assert.IsTrue(a == b, "True");
        }
    }
}
