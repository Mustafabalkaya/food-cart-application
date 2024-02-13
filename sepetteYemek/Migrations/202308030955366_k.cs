namespace sepetteYemek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                {
                    AdminID = c.Int(nullable: false, identity: true),
                    KullaniciAd = c.String(),
                    Sifre = c.String(),
                    Rol = c.String(),
                })
                .PrimaryKey(t => t.AdminID);
        }
        
        public override void Down()
        {
            DropTable("Admins");



        }
    }
}
