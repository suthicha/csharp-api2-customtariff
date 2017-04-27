using CustomTariff.Api2.DataAccess;
using CustomTariff.Api2.Models;
using System.Linq;
using System.Web.Http;

namespace CustomTariff.Api2.Controllers
{
    public class ProductTariffController : BaseApiController
    {
        public ProductTariffController() : base(new ModelFactory(), new AppDbService())
        {
        }

        public IHttpActionResult Get()
        {
            var commandText = @"SELECT TOP 100 CompanyCode, DivisionCode, Section, Formality, TypeOfProduct, PartName,
            SPEC, FullPartName, MadeBy, Unit, PdtDescriptionTH, TariffCode, StatCode, TariffUnit, DutyRate,
            PdtDescriptionAddon, NewTariffCode, NewStatCode, NewTariffUnit, NewDutyRate, NeedLicense, Ministry,
            PdtClass, CustomsFunc, UsedForMachine, CropPlanningRemark, Filter1, Filter2, Filter3, Filter4, Filter5,
            Filter6, Remark1, Remark2, OPRCode, PRGCode, CreateDate, GroupId, StatusTariffCode, StatusStatCode,
            StatusTariffUnit, StatusDutyRate, TrxId, Remark FROM ProductTariffs ORDER By TrxId ASC";

            var productTariffEntity = AppDbService.ProductTariffs.Select(commandText, "");
            var productTariffModels = productTariffEntity.Select(ModelFactory.Create);

            return Ok(productTariffModels);
        }
    }
}