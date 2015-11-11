namespace Ejercicio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correciondep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "Departamento_id" });
            RenameColumn(table: "dbo.Empleadoes", name: "Departamento_id", newName: "Departamentoid");
            AlterColumn("dbo.Empleadoes", "Departamentoid", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleadoes", "Departamentoid");
            AddForeignKey("dbo.Empleadoes", "Departamentoid", "dbo.Departamentoes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "Departamentoid", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "Departamentoid" });
            AlterColumn("dbo.Empleadoes", "Departamentoid", c => c.Int());
            RenameColumn(table: "dbo.Empleadoes", name: "Departamentoid", newName: "Departamento_id");
            CreateIndex("dbo.Empleadoes", "Departamento_id");
            AddForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes", "id");
        }
    }
}
