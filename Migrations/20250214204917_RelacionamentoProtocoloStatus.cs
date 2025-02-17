using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProtocolSystem.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoProtocoloStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFechamento",
                table: "Protocolos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos",
                column: "ProtocoloStatusId",
                principalTable: "StatusProtocolos",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFechamento",
                table: "Protocolos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Protocolos_StatusProtocolos_ProtocoloStatusId",
                table: "Protocolos",
                column: "ProtocoloStatusId",
                principalTable: "StatusProtocolos",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
