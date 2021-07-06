using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IStoreFrontRepository
    {
        /// <summary>
        /// Get All Store Front from the database
        /// </summary>
        /// <returns>list of store front</returns>
        List<StoreFronts> GetAllStoreFronts();

        List<StoreFronts> SearchStoreFront(string p_criteria, string p_value);

    }
}