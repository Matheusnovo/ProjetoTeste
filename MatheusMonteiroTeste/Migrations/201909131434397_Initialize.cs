namespace MatheusMonteiroTeste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
