using CustomTariff.Api2.DataAccess.Entities;
using CustomTariff.Api2.DataAccess.Repositories;

namespace CustomTariff.Api2.DataAccess
{
    public class AppDbService : IAppDbService
    {
        private Repository<Product> _products;

        private Repository<ProductTariff> _productTariffs;

        public Repository<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(new AppDbContext());
                return _products;
            }
        }

        public Repository<ProductTariff> ProductTariffs
        {
            get
            {
                if (_productTariffs == null)
                    _productTariffs = new ProductTariffRepository(new AppDbContext());
                return _productTariffs;
            }
        }
    }
}