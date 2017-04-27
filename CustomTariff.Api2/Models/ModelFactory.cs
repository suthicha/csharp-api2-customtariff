using CustomTariff.Api2.DataAccess.Entities;
using CustomTariff.Models;
using System;

namespace CustomTariff.Api2.Models
{
    public class ModelFactory : IModelFactory
    {
        public ProductTariffModel Create(ProductTariff productTariff)
        {
            return new ProductTariffModel
            {
                id = productTariff.TrxId,
                groupId = productTariff.GroupId,
                companyCode = productTariff.CompanyCode,
                divisionCode = productTariff.DivisionCode,
                section = productTariff.Section,
                formality = productTariff.Formality,
                typeofProduct = productTariff.TypeOfProduct,
                partName = productTariff.PartName,
                spec = productTariff.SPEC,
                fullPartName = productTariff.FullPartName,
                madeBy = productTariff.MadeBy,
                unit = productTariff.Unit,
                pdtDescriptionTH = productTariff.PdtDescriptionTH,
                tariffCode = productTariff.TariffCode,
                statCode = productTariff.StatCode,
                tariffUnit = productTariff.TariffUnit,
                dutyRate = productTariff.DutyRate,
                pdtDescriptionAddon = productTariff.PdtDescriptionAddon,
                newTariffCode = productTariff.NewTariffCode,
                newStatCode = productTariff.NewStatCode,
                newTariffUnit = productTariff.NewTariffUnit,
                newDutyRate = productTariff.NewDutyRate,
                statusTariffCode = productTariff.StatusTariffCode,
                statusStatCode = productTariff.StatusStatCode,
                statusTariffUnit = productTariff.StatusTariffUnit,
                statusDutyRate = productTariff.StatusDutyRate,
                remark = productTariff.Remark
            };
        }

        public ProductModel Create(Product product)
        {
            return new ProductModel
            {
                id = product.TrxId,
                companyCode = product.CompanyCode,
                divisionCode = product.DivisionCode,
                section = product.Section,
                formality = product.Formality,
                typeofProduct = product.TypeOfProduct,
                partname = product.PartName,
                spec = product.SPEC,
                fullPartname = product.FullPartName,
                madeby = product.MadeBy,
                unit = product.Unit,
                pdtDescriptionTH = product.PdtDescriptionTH,
                tariffCode = product.TariffCode,
                tariffSeq = product.TariffSeq,
                tariffUnit = product.TariffUnit,
                dutyRate = product.DutyRate,
                needLicense = product.NeedLicense,
                ministry = product.Ministry,
                pdtClass = product.PdtClass,
                customsFunc = product.CustomsFunc,
                usedForMachine = product.UsedForMachine,
                cropPlanningRemark = product.CropPlanningRemark,
                filter1 = product.Filter1,
                filter2 = product.Filter2,
                filter3 = product.Filter3,
                filter4 = product.Filter4,
                filter5 = product.Filter5,
                filter6 = product.Filter6,
                remark1 = product.Remark1,
                remark2 = product.Remark2,
                operationCode = product.OPRCode,
                programCode = product.PRGCode,
                createBy = product.CreateBy,
                createDate = product.CreateDate,
                updateBy = product.UpdateBy,
                updateDate = product.UpdateDate
            };
        }
    }
}