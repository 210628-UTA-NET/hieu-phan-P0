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
            string fname = "qweas asdd";
            
            //Act
            test.Fname = fname;
            
            //Assert
            Assert.Equal(fname, test.Fname);
        }

        /// <summary>
        /// This test will check if validation works in Customers Model
        /// It will put information that will be wrong and should throw an exception
        /// </summary>
        /// <param name="input">This is the input that our test case will check in Act</param>
        [Theory]
        [InlineData("qwe123")]
        [InlineData("qwe!@#@!#")]
        public void FnameShouldNotSetInvalidData(string input)
        {
            //Arrange
            Customers test = new Customers();

            //Act and Assert together
            Assert.Throws<Exception>(() => test.Fname = input);

        }
    }
}
