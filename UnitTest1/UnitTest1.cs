using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void UserCanNavigateToFuelTabFromHomepage()
        {
            var User = UserNavigatesToFuelTab();

        }
    }

    internal class appUser
    {
        // This class should contain attributes that the user should have when they initially click on the fuel tab
        // This means that the user should have an empty iternairy 


    }
}
