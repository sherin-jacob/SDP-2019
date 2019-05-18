using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2.View;
using Xamarin.Forms;

namespace UnitTests
{
    [TestClass]
    public class AddIternairyTests
    {
        private static bool name;
        private AttractionsPage _clickedOnDate;
        private object AddItineraryViewModel;
        private object _timePicker;

        public static string Navigation { get; private set; }
        public object Date { get; private set; }

        [TestMethod]
        public void ClickOnDateAndCalanderDisplaysToSelectDate()
        {
            var clickOnDate = new AddIternairyTests();
            //_clickedOnDate = AddItineraryViewModel.clickOnDate(DateTime Date);
            Assert.AreEqual(_timePicker, null);
        }

        [TestMethod]
        public void SavedIternairyNameTrue()
        {
            var name = new ResourceDictionary();
            _timePicker = AddIternairyTests.name;
            Assert.IsFalse(AddIternairyTests.name, AddIternairyTests.Navigation);
        }
    }
}

    