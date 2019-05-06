using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2.View;

namespace NZTravelTest
{
    [TestClass]
    public class AttractionDetailsPageTests
    {
        public object AttractionDetailPageTests { get; private set; }
        public object MapViewButton_Clicked { get; private set; }
        public static object options { get; set; }

        [TestMethod]

        public void CheckIfMapButtonIsClicked()
        {
            //Confirming that the map button has been clicked
            // Arrange - check button clicked - calling the button method from the AttractionDetailPage
            var mapButtonClicked = new AttractionDetailPage();

            // Act
            //mapButtonClicked = AttractionDetailPageTests.place.Name(options);

            //Assert
            Assert.AreEqual(AttractionDetailPage.location, AttractionDetailPage.options);
        }

    }

       // public void GetAttractionDetailsTest()
       // {
            ///vattractionDetails = new AttractionDetailPage;
            



}
    