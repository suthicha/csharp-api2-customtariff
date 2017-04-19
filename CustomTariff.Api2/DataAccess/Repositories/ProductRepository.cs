using CustomTariff.Api2.DataAccess.Entities;

namespace CustomTariff.Api2.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}