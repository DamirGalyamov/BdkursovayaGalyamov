using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class PHiSIGId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sig0s",
                table: "Sig0s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phi0s",
                table: "Phi0s");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Sig0s",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Phi0s",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sig0s",
                table: "Sig0s",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phi0s",
                table: "Phi0s",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sig0s",
                table: "Sig0s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phi0s",
                table: "Phi0s");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sig0s");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Phi0s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sig0s",
                table: "Sig0s",
                column: "EnterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phi0s",
                table: "Phi0s",
                column: "EnterId");
        }
    }
}
