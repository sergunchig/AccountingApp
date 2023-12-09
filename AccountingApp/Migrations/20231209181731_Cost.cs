using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingApp.Migrations
{
    /// <inheritdoc />
    public partial class Cost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Costs");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Costs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Costs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Costs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Costs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Costs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
