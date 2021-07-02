using System;
using SSDModel;
using Xunit;

namespace SSDTest
{
    public class CustomersModelTest
    {
        /// <summary>
        /// This test will check if validation works in Customers Model
        /// It will input the right data and see if it persists
        /// </summary>
        [Fact]
        public void NameShouldSetValidData()
        {
            //Arrange
            Customers test = new Customers();
            string name = "qweasd";
            
            //Act
            test.Name = name;
            
            //Assert
            Assert.Equal(name, test.Name);
        }
    }
}
