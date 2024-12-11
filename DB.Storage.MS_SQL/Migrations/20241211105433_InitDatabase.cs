using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Belt_Characteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    profile_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sectional_area = table.Column<double>(type: "float", nullable: false),
                    Loginlinear_density = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belt_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enter_Values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    belt_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    profile_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Z = table.Column<double>(type: "float", nullable: false),
                    C3 = table.Column<double>(type: "float", nullable: false),
                    F = table.Column<double>(type: "float", nullable: false),
                    xi = table.Column<double>(type: "float", nullable: false),
                    alpha1 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enter_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KofC1s",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    alpha1 = table.Column<double>(type: "float", nullable: false),
                    C1 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KofC1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Out_Values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enter_valuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sigma0 = table.Column<double>(type: "float", nullable: false),
                    Q0 = table.Column<double>(type: "float", nullable: false),
                    R = table.Column<double>(type: "float", nullable: false),
                    teta = table.Column<double>(type: "float", nullable: false),
                    Enter_ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Out_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Out_Values_Enter_Values_Enter_ValueId",
                        column: x => x.Enter_ValueId,
                        principalTable: "Enter_Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phi0s",
                columns: table => new
                {
                    EnterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    enter_phi0 = table.Column<double>(type: "float", nullable: false),
                    Enter_ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phi0s", x => x.EnterId);
                    table.ForeignKey(
                        name: "FK_Phi0s_Enter_Values_Enter_ValueId",
                        column: x => x.Enter_ValueId,
                        principalTable: "Enter_Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sig0s",
                columns: table => new
                {
                    EnterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    enter_sig0 = table.Column<double>(type: "float", nullable: false),
                    Enter_ValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sig0s", x => x.EnterId);
                    table.ForeignKey(
                        name: "FK_Sig0s_Enter_Values_Enter_ValueId",
                        column: x => x.Enter_ValueId,
                        principalTable: "Enter_Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Out_Values_Enter_ValueId",
                table: "Out_Values",
                column: "Enter_ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Phi0s_Enter_ValueId",
                table: "Phi0s",
                column: "Enter_ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Sig0s_Enter_ValueId",
                table: "Sig0s",
                column: "Enter_ValueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Belt_Characteristics");

            migrationBuilder.DropTable(
                name: "KofC1s");

            migrationBuilder.DropTable(
                name: "Out_Values");

            migrationBuilder.DropTable(
                name: "Phi0s");

            migrationBuilder.DropTable(
                name: "Sig0s");

            migrationBuilder.DropTable(
                name: "Enter_Values");
        }
    }
}
