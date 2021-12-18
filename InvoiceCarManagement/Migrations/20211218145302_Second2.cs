using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceCarManagement.Migrations
{
    public partial class Second2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceProductId",
                table: "InvoiceDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetailes_InvoiceProductId",
                table: "InvoiceDetailes",
                column: "InvoiceProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetailes_invoiceProducts_InvoiceProductId",
                table: "InvoiceDetailes",
                column: "InvoiceProductId",
                principalTable: "invoiceProducts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetailes_invoiceProducts_InvoiceProductId",
                table: "InvoiceDetailes");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetailes_InvoiceProductId",
                table: "InvoiceDetailes");

            migrationBuilder.DropColumn(
                name: "InvoiceProductId",
                table: "InvoiceDetailes");
        }
    }
}
