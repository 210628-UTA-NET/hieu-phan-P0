using System;
using SSDModel;

namespace SSDBL
{
    /// <summary>
    /// Handles all the business logic for the restaunrant model
    /// They are in charge of further processing/ sanitizing/ further validation of data
    /// Any logic that is used to access the data is for the DL, anything else will be in BL
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// When the write menu is press, a customer will be created using user inputs
        /// </summary>
        /// <returns>a customer object</returns>
        Customers CreateCustomer();

    }
}