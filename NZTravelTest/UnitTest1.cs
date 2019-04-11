using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
using NZTravel2.View;

namespace NZTravelTest
{
    [TestClass]
    public class UnitTest1
    {
        //private static double longtest;
        [TestMethod]
        public void Test_GetLongitude()
        {
            MapPage nzt2 = new MapPage();
            var longtest = nzt2.Longitude();
            Assert.AreEqual(longtest, 174.7673);
        }
    }
}
