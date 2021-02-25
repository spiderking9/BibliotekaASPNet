namespace BibliotekaProgmat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ksiazkas",
                c => new
                    {
                        Idksiazki = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 30),
                        Autor = c.String(nullable: false, maxLength: 30),
                        DataWydania = c.DateTime(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Idksiazki);
            
            CreateTable(
                "dbo.Rezerwacjas",
                c => new
                    {
                        IdRezerwacji = c.Int(nullable: false, identity: true),
                        IdKsiazki = c.Int(nullable: false),
                        DataRezerwacji = c.DateTime(nullable: false),
                        IdUser = c.String(),
                    })
                .PrimaryKey(t => t.IdRezerwacji)
                .ForeignKey("dbo.Ksiazkas", t => t.IdKsiazki, cascadeDelete: true)
                .Index(t => t.IdKsiazki);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezerwacjas", "IdKsiazki", "dbo.Ksiazkas");
            DropIndex("dbo.Rezerwacjas", new[] { "IdKsiazki" });
            DropTable("dbo.Rezerwacjas");
            DropTable("dbo.Ksiazkas");
        }
    }
}
