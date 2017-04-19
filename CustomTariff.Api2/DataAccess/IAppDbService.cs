using CustomTariff.Api2.DataAccess.Entities;
using CustomTariff.Api2.DataAccess.Repositories;

namespace CustomTariff.Api2.DataAccess
{
    public interface IAppDbService
    {
        Repository<Product> Products { get; }
    }
}