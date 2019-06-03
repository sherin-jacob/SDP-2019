using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test2
{
    [TestClass]
    public class EditTest
    {
        
        public object Navigation { get; private set; }

        [TestMethod]
        public void ViewEditButtonTest()
        {
            var _viewEditButton = new EditTest();
            _viewEditButton.ViewEditButtonTest(Navigation);
            Assert.IsTrue(true, "");
        }

        private void ViewEditButtonTest(object navigation)
        {
            ViewEditButtonTest(navigation);
        }
    }
}
