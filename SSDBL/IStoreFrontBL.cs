using System.Collections.Generic;
using SSDModel;

namespace SSDBL
{
    public interface IStoreFrontBL
    {
        List<StoreFronts> GetAllStoreFronts();
        StoreFronts GetAStore(int p_id);

        List<StoreFronts> SearchStoreFronts(string p_criteria, string p_value);
    }
}
