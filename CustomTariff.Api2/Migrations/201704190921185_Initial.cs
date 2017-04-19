namespace CustomTariff.Api2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        TrxId = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(maxLength: 2, unicode: false),
                        DivisionCode = c.String(maxLength: 2, unicode: false),
                        Section = c.String(maxLength: 2, unicode: false),
                        Formality = c.String(maxLength: 15, unicode: false),
                        TypeOfProduct = c.String(maxLength: 15, unicode: false),
                        PartName = c.String(maxLength: 255, unicode: false),
                        SPEC = c.String(maxLength: 255, unicode: false),
                        FullPartName = c.String(maxLength: 512, unicode: false),
                        MadeBy = c.String(maxLength: 15, unicode: false),
                        Unit = c.String(maxLength: 6, unicode: false),
                        PdtDescriptionTH = c.String(maxLength: 512, unicode: false),
                        TariffCode = c.String(maxLength: 35, unicode: false),
                        TariffSeq = c.String(maxLength: 15, unicode: false),
                        TariffUnit = c.String(maxLength: 6, unicode: false),
                        DutyRate = c.Double(nullable: false),
                        NeedLicense = c.Boolean(nullable: false),
                        Ministry = c.String(maxLength: 15, unicode: false),
                        PdtClass = c.String(maxLength: 15, unicode: false),
                        CustomsFunc = c.String(maxLength: 512, unicode: false),
                        UsedForMachine = c.String(maxLength: 512, unicode: false),
                        CropPlanningRemark = c.String(maxLength: 512, unicode: false),
                        Filter1 = c.String(maxLength: 512, unicode: false),
                        Filter2 = c.String(maxLength: 512, unicode: false),
                        Filter3 = c.String(maxLength: 512, unicode: false),
                        Filter4 = c.String(maxLength: 512, unicode: false),
                        Filter5 = c.String(maxLength: 512, unicode: false),
                        Filter6 = c.String(maxLength: 512, unicode: false),
                        Remark1 = c.String(maxLength: 512, unicode: false),
                        Remark2 = c.String(maxLength: 512, unicode: false),
                        OPRCode = c.String(maxLength: 15, unicode: false),
                        PRGCode = c.String(maxLength: 15, unicode: false),
                        CreateBy = c.String(maxLength: 35, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 35, unicode: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrxId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
