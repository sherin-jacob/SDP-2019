using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
using NZTravel2.View;

namespace NZTravelTest
{
    [TestClass]
    public class FuelPageTests
    {
        public object _fuelButtonClicked { get; private set; }

        [TestMethod]
        // When fuel button is clicked the fuel tab should display 
        public void RetreiveFuelTabLocationTest()
        {
            var fuelButtonClicked = new FuelPage();
            _fuelButtonClicked = FuelPage.Location;
            Assert.IsNull(_fuelButtonClicked, null);
        }
    }
}

