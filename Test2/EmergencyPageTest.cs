using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2
{
    [TestClass]
    public class EmergencyPageTest
    {
        [TestMethod]
        public void ViewEmergencyPageTest()
        {
            var _viewEmergencyPage = new EmergencyPageTest();
            _viewEmergencyPage.ViewEmergencyPageTest();
            Assert.IsTrue(true, "");
        }

        [TestMethod]
        public void TrafficButtonClickedTest()
        {
            var _viewTrafficButtonClicked = new EmergencyPageTest();
            _viewTrafficButtonClicked.ViewEmergencyPageTest();
            Assert.IsTrue(true, "");
        }
    }
}
