namespace Stok_Takip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanıcılars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ürünlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Fiyat = c.Int(nullable: false),
                        Ülke = c.String(),
                        İşlem_Tarihi = c.DateTime(nullable: false),
                        Notlar = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ürünlers");
            DropTable("dbo.Kullanıcılars");
        }
    }
}
