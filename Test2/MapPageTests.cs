using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
using NZTravel2.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using System.Linq;

namespace NZTravelTest
{
    [TestClass]
    public class MapPageTests
    {

    [TestMethod]
    //Improving previous tests
    public void GetCoordinatesOfLongitudeTest()
        {
            //Arrange 
           
        }


      /*  [TestMethod]
        public void GetLongitudeValuesTest()
        {
            MapPage nzt2 = new MapPage();
            var longtest = nzt2.Longitude();
            Assert.AreEqual(longtest, 0); //testing the location values that are in the emulator
        }

        [TestMethod]
        public void GetLatitudeValuesTest()
        {
            MapPage nzt2 = new MapPage();
            var lattest = nzt2.Latitude();
            Assert.AreEqual(lattest, 0); //testing the location values that are in the emulator
        }

        [TestMethod]
        public async Task DisplayMapPageOnButtonClick()
        {
            var root = new HomePage();
            var page = new MapPage();
            await root.Navigation.PushAsync(page);
            Assert.AreEqual(root.Navigation.NavigationStack.Last(), page);
        }

        [TestMethod]
        public async Task DisplayFuelPageOnButtonClick()
        {
            var root = new HomePage();
            var page = new FuelPage();
            await root.Navigation.PushAsync(page);
            Assert.AreEqual(root.Navigation.NavigationStack.Last(), page);
        }
    */
       /* [TestMethod]
        public async Task DisplayItineraryPageOnButtonClick()
        {
            var root = new HomePage();
            var page = new ItineraryView();
            await root.Navigation.PushAsync(page);
            Assert.AreEqual(root.Navigation.NavigationStack.Last(), page);
        }
       */
        //[TestMethod]
        //public async Task ShowLocationTest()
        //{
        //    SetUp();
        //    var root = new MapPage();
        //    await root.ShowPlace("Auckland Museum");
        //    Assert.AreEqual(1, root.GetX());
        //}

        //[TestMethod]
        //public async Task GetDate()
        //{
        //    SetUp();
        //    int count = 1;
        //    await App.ItineraryRepository.AddItem(new Itinerary { Title = "Hello", time = new TimeSpan(3, 30, 0), date = new DateTime(2019,05,06) });
        //    int x = await App.ItineraryRepository.countAsync();
        //    Assert.AreEqual(1, x);
        //}

    }
}