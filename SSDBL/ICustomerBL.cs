using System.Collections.Generic;
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
        /// get all customers from database
        /// </summary>
        /// <returns>return a list of restaurant</returns>
        List<Customers> GetAllCustomers();

        /// <summary>
        /// The method will then send the customer to repository to be written to file
        /// return true if the attempt is successful
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns></returns>
        Customers AddCustomer(Customers p_customer);
        
        /// <summary>
        /// Search customer using a criteria
        /// </summary>
        /// <returns>customer list with the same criteria</returns>
        List<Customers> SearchCustomer(string p_criteria, string p_value);
        
    }
}