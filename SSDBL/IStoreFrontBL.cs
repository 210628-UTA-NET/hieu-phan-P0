using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface IStoreFrontBL
    {
        List<StoreFronts> GetAllStoreFronts();

        List<StoreFronts> SearchStoreFronts(string p_criteria, string p_value);
    }
}
