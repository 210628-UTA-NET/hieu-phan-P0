using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IStoreFrontDL
    {
        /// <summary>
        /// Get All Store Front from the database
        /// </summary>
        /// <returns>list of store front</returns>
        List<StoreFronts> GetAllStoreFronts();
        StoreFronts GetAStore(int p_id);

        List<StoreFronts> SearchStoreFront(string p_criteria, string p_value);

    }
}