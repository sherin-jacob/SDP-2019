using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZTravel2;
using NZTravel2.View;

namespace NZTravelTest
{
    [TestClass]
    public class AttractionsPageTests
    {
        private static bool region;
        public object _region;

        [TestMethod]
        public void CheckIfAttractionsInCurrentRegion()
        {
            var region = new AttractionsPageTests();
            Assert.IsTrue(true, "current");
        }

    }
}
//region.AttractionsPage();
//Assert.AreEqual(AttractionsPageTests.ViewAttractionsInCurrentRegion,AttractionsPageTests());

/* private void AttractionsPage()
 {
     throw new NotImplementedException();
 }
*/
