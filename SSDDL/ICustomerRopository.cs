using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    /// <summary>
    /// It is responsible for accessing our database (in this case it will be a JSON file stored in our folder)
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// This method will add a customer to the json file
        /// </summary>
        /// <param name="p_customer">this is the customer obj that will be added to the database</param>
        /// <returns></returns>
        Customers AddCustomer(Customers p_customer);

        List<Customers> GetAllCustomers();

        /// <summary>
        /// Search and return a list of customer that match a pair of criteria and value input
        /// </summary>
        /// <param name="p_criteria"></param>
        /// <param name="p_value"></param>
        /// <returns></returns>
        List<Customers> SearchCustomer(string p_criteria, string p_value);
    }
}
