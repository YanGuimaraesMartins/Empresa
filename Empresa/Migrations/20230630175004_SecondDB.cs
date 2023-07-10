using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Migrations
{
    public partial class SecondDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Funcionarios",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
