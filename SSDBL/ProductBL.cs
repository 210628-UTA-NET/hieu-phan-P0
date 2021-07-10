using System.Collections.Generic;
using SSDModel;
using SSDDL;

namespace SSDBL
{
    public class ProductBL : IProductBL
    {
        private IProductDL _repo;
        public ProductBL(IProductDL p_repo)
        {
            _repo = p_repo;
        }

        public List<Products> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

    }
}