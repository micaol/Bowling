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
            DbFileController.StartDB();  
            
            string savedData = "2 3 10 0 5 "; 
            DbFileController.Save(2);
            DbFileController.Save(3);
            DbFileController.Save(10);
            DbFileController.Save(0);
            DbFileController.Save(5);
            string loadedData = DbFileController.Load(); 

            Assert.True(savedData == loadedData); 
        }
    }
}