using System;
using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    /// <summary>
    /// It is responsible for accessing our database (in this case it will be a JSON file stored in our folder)
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// This method will add a customer to the json file
        /// </summary>
        /// <param name="p_customer">this is the customer obj that will be added to the database</param>
        /// <returns></returns>
        bool AddCustomer(Customers p_customer);

        
    }
}
