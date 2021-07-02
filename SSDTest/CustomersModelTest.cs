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
            string name = "qweas asdd";
            
            //Act
            test.Name = name;
            
            //Assert
            Assert.Equal(name, test.Name);
        }

        /// <summary>
        /// This test will check if validation works in Customers Model
        /// It will put information that will be wrong and should throw an exception
        /// </summary>
        /// <param name="input">This is the input that our test case will check in Act</param>
        [Theory]
        [InlineData("qwe123")]
        [InlineData("qwe!@#@!#")]
        public void CityShouldNotSetInvalidData(string input)
        {
            //Arrange
            Customers test = new Customers();

            //Act and Assert together
            Assert.Throws<Exception>(() => test.Name = input);

        }
    }
}
