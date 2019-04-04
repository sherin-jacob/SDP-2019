using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2.View;

namespace NZTravelTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetLongitude()
        {
            MapPage nzt2 = new MapPage();
            var longitude = nzt2.Longitude(174.7673);
            Assert.AreEqual(longitude, 174.7673);
        }
    }
}
