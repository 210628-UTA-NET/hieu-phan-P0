using SSDModel;
using SSDDL;
using System.Collections.Generic;

namespace SSDBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontDL _repo;
        public StoreFrontBL(IStoreFrontDL p_repo)
        {
            _repo = p_repo;
        }


        public List<StoreFronts> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public StoreFronts GetAStore(int p_id)
        {
            return _repo.GetAStore(p_id);
        }

        public List<StoreFronts> SearchStoreFronts(string p_criteria, string p_value)
        {
            return _repo.SearchStoreFront(p_criteria, p_value);
        }
    }
}