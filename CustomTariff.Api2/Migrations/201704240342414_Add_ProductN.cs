namespace CustomTariff.Api2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ProductN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductNs",
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
                        PdtDescriptionAddOn = c.String(maxLength: 512, unicode: false),
                        TariffCode = c.String(maxLength: 35, unicode: false),
                        TariffSeq = c.String(maxLength: 15, unicode: false),
                        TariffUnit = c.String(maxLength: 6, unicode: false),
                        DutyRate = c.Double(nullable: false),
                        NewTariffCode = c.String(maxLength: 35, unicode: false),
                        NewTariffSeq = c.String(maxLength: 15, unicode: false),
                        NewTariffUnit = c.String(maxLength: 6, unicode: false),
                        NewDutyRate = c.Double(nullable: false),
                        GroupId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 35, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 35, unicode: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrxId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductNs");
        }
    }
}
