using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public class ProductDL : IProductDL
    {
        private Entities.DemoDbContext _context;
        public ProductDL (Entities.DemoDbContext p_context)
        {
            _context = p_context;
        }
        public List<Products> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}