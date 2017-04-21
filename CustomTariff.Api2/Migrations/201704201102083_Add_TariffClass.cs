namespace CustomTariff.Api2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_TariffClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TariffClasses",
                c => new
                    {
                        TrxId = c.Int(nullable: false, identity: true),
                        OldTariffCode = c.String(maxLength: 35, unicode: false),
                        TariffCode = c.String(maxLength: 35, unicode: false),
                        RefType = c.String(maxLength: 15, unicode: false),
                        Remark1 = c.String(maxLength: 512, unicode: false),
                        Remark2 = c.String(maxLength: 512, unicode: false),
                        CreateBy = c.String(maxLength: 35, unicode: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 35, unicode: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrxId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TariffClasses");
        }
    }
}
