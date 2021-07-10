using System.Collections.Generic;
using SSDModel;
using System.Linq;

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
            return _context.Products.Select(
                prod =>
                    new Products()
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = (double)prod.Price,
                        Description = prod.Description,
                        Category = prod.Category
                    }
            ).ToList();
        }
    }
}