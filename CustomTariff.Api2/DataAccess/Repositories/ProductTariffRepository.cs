using CustomTariff.Api2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomTariff.Api2.DataAccess.Repositories
{
    public class ProductTariffRepository : Repository<ProductTariff>
    {
        public ProductTariffRepository(AppDbContext context) : base(context)
        {
        }
    }
}