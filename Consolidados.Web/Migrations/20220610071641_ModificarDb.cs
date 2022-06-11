using Microsoft.EntityFrameworkCore.Migrations;

namespace Consolidados.Web.Migrations
{
    public partial class ModificarDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContainerId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Payload = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_ContainerId",
                table: "States",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContainerName",
                table: "Containers",
                column: "ContainerName",
                unique: true,
                filter: "[ContainerName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ContractId",
                table: "Containers",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Containers_ContainerId",
                table: "States",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Containers_ContainerId",
                table: "States");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_States_ContainerId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                table: "States");
        }
    }
}
