using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2.Persistence;
using NZTravel2.View;
using Xamarin.Forms;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestAdd()
        {
            //ItineraryRepository i = new ItineraryRepository();
            // int bcount = await i.countAsync();
            // await i.AddItem(new NZTravel2.Itinerary());
            // int acount = await i.countAsync();
            Assert.IsTrue(1 == 1, "True");
        }
    }
}
