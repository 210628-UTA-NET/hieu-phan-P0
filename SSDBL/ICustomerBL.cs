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

        /// <summary>
        /// The method will then send the customer to repository to be written to file
        /// return true if the attempt is successful
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns></returns>
        bool SendCustomer(Customers p_customer);
    }
}