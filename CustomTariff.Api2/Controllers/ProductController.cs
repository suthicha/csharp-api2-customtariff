using CustomTariff.Api2.DataAccess;
using CustomTariff.Api2.Models;
using CustomTariff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomTariff.Api2.Controllers
{
    public class ProductController : BaseApiController
    {
        public ProductController() : base(new ModelFactory(), new AppDbService())
        {
        }

        public IHttpActionResult Get()
        {
            return null;
        }
    }
}