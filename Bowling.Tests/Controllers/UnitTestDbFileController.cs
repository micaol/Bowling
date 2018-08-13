using System;
using System.Collections.Generic;
using Bowling.Controllers;
using Xunit;

namespace Bowling.Tests.Controllers
{
    public class UnitTestDbFileController
    {
        /// <summary>
        ///     Write integers to a file.
        ///     Read the values.
        ///     Check the data loaded. 
        /// </summary>
        [Fact]
        public void TestSaveLoad()
        {
            var dbController = new DbFileController();
            dbController.ClearDB(); 
            string savedData = "2 3 10 0 5 "; 
            dbController.Save("2");
            dbController.Save("3");
            dbController.Save("10");
            dbController.Save("0");
            dbController.Save("5");
            string loadedData = dbController.Load(); 

            Assert.True(savedData == loadedData); 
        }
    }
}