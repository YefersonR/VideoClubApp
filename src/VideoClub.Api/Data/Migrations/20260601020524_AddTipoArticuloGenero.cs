using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoClub.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoArticuloGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposArticulosGeneros",
                columns: table => new
                {
                    TipoArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    GeneroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposArticulosGeneros", x => new { x.TipoArticuloId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_TiposArticulosGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposArticulosGeneros_TiposArticulos_TipoArticuloId",
                        column: x => x.TipoArticuloId,
                        principalTable: "TiposArticulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposArticulosGeneros_GeneroId",
                table: "TiposArticulosGeneros",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposArticulosGeneros_TipoArticuloId",
                table: "TiposArticulosGeneros",
                column: "TipoArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposArticulosGeneros");
        }
    }
}
