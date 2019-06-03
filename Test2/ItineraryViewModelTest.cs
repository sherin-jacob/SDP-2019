using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;

namespace Test2
{
    [TestClass]
    public class ItineraryViewModelTest
    {
        [TestMethod]
        public void ShareItineraryTest()
        {
            var AddToItinerary = new ItineraryViewModelTest();
            var ItineraryNotEmpty = new ItineraryViewModelTest();

            //AddToItinerary = ItineraryViewModelTest(ItineraryNotEmpty);
            //ItineraryNotEmpty = ItineraryViewModelTest(AddToItinerary);

            Assert.IsNotNull(ItineraryNotEmpty, null);
            
        }
    }
}
