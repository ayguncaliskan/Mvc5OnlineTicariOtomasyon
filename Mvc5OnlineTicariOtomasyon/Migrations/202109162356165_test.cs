namespace Mvc5OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelGorsel", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.Personels", "PersonelGörsel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personels", "PersonelGörsel", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.Personels", "PersonelGorsel");
        }
    }
}
