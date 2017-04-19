using CustomTariff.Api2.DataAccess;
using CustomTariff.Api2.Models;
using System.Web.Http;

namespace CustomTariff.Api2.Controllers
{
    public class BaseApiController : ApiController
    {
        private IAppDbService _appDbService;
        private IModelFactory _modelFactory;

        protected BaseApiController(IModelFactory modelFactory, IAppDbService appDbService)
        {
            _modelFactory = modelFactory;
            _appDbService = appDbService;
        }

        protected IModelFactory ModelFactory
        {
            get
            {
                return _modelFactory;
            }
        }

        protected IAppDbService AppDbService
        {
            get
            {
                return _appDbService;
            }
        }
    }
}