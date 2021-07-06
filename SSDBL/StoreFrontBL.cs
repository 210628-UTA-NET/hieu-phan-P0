using SSDModel;
using SSDDL;
using System.Collections.Generic;

namespace SSDBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreFrontRepository _repo;
        public StoreFrontBL(IStoreFrontRepository p_repo)
        {
            _repo = p_repo;
        }


        public List<StoreFronts> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public List<StoreFronts> SearchStoreFronts(string p_criteria, string p_value)
        {
            return _repo.SearchStoreFront(p_criteria, p_value);
        }
    }
}