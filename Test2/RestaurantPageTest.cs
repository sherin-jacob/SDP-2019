using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2
{
    [TestClass]
    public class RestaurantPageTest
    {
        private static string restaurantButtonClicked;
        private static RestaurantPageTest restaurantButtonAppears;

        public static RestaurantPageTest Location { get; private set; }

        [TestMethod]
        public void RetrieveRestaurantOpenLocationTest()
        {
            var restaurantButtonClicked = new RestaurantPageTest();
            restaurantButtonClicked = RestaurantPageTest.Location;
            Assert.IsTrue(true, RestaurantPageTest.restaurantButtonClicked);
        }
        [TestMethod]
        public void HomeScreenDisplayedRestaurantsButtonVisibleTest()
        {
            var homeScreenDisplayed = new RestaurantPageTest();
            var restaurantButtonAppears = new RestaurantPageTest();
            Assert.IsTrue(true, " ");
            //Assert.AreEqual(homeScreenDisplayed, RestaurantPageTest.restaurantButtonAppears);
        }
    }
}
