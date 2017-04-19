using CustomTariff.Api2.DataAccess.Entities;
using CustomTariff.Models;

namespace CustomTariff.Api2.Models
{
    public interface IModelFactory
    {
        ProductModel Create(Product product);
    }
}