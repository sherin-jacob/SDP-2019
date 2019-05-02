using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
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
            var longtest = nzt2.Longitude();
            Assert.AreEqual(longtest, 174.532); //testing the location values that are in the emulator
        }

        [TestMethod]
        public void Test_GetLatitude()
        {
            MapPage nzt2 = new MapPage();
            var lattest = nzt2.Latitude();
            Assert.AreEqual(lattest, -36.7625); //testing the location values that are in the emulator
        }
    }
}
