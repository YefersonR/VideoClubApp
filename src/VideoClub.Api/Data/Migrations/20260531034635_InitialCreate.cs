using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VideoClub.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    no_tarjeta_cr = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValue: 0m),
                    TipoPersona = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.CheckConstraint("CK_Clientes_NoTarjetaCr", "no_tarjeta_cr ~ '^[0-9]{4}$'");
                });

            migrationBuilder.CreateTable(
                name: "Elenco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elenco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    tanda_labor = table.Column<string>(type: "text", nullable: false),
                    PorcientoComision = table.Column<decimal>(type: "numeric(5,2)", nullable: false, defaultValue: 0m),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.CheckConstraint("CK_Empleados_TandaLabor", "tanda_labor IN ('Matutina', 'Vespertina')");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesElenco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesElenco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposArticulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposArticulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    TipoArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    GeneroId = table.Column<long>(type: "bigint", nullable: false),
                    IdiomaId = table.Column<long>(type: "bigint", nullable: false),
                    renta_por_dia = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DiasRenta = table.Column<int>(type: "integer", nullable: false, defaultValue: 3),
                    MontoEntregaTardia = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValue: 0m),
                    Stock = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Idiomas_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "Idiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_TiposArticulos_TipoArticuloId",
                        column: x => x.TipoArticuloId,
                        principalTable: "TiposArticulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElencoArticulo",
                columns: table => new
                {
                    ArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    ElencoId = table.Column<long>(type: "bigint", nullable: false),
                    RolElencoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElencoArticulo", x => new { x.ArticuloId, x.ElencoId, x.RolElencoId });
                    table.ForeignKey(
                        name: "FK_ElencoArticulo_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElencoArticulo_Elenco_ElencoId",
                        column: x => x.ElencoId,
                        principalTable: "Elenco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElencoArticulo_RolesElenco_RolElencoId",
                        column: x => x.RolElencoId,
                        principalTable: "RolesElenco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentaDevolucion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoRenta = table.Column<string>(type: "text", nullable: false),
                    EmpleadoId = table.Column<long>(type: "bigint", nullable: false),
                    ArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    fecha_renta = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_devolucion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    MontoXdia = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    cantidad_dias = table.Column<int>(type: "integer", nullable: false),
                    DiasRetraso = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    fecha_modificacion = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    usuario_creacion = table.Column<string>(type: "text", nullable: false),
                    usuario_modificacion = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentaDevolucion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentaDevolucion_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentaDevolucion_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentaDevolucion_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_GeneroId",
                table: "Articulos",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdiomaId",
                table: "Articulos",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoArticuloId",
                table: "Articulos",
                column: "TipoArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElencoArticulo_ArticuloId",
                table: "ElencoArticulo",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ElencoArticulo_ElencoId",
                table: "ElencoArticulo",
                column: "ElencoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElencoArticulo_RolElencoId",
                table: "ElencoArticulo",
                column: "RolElencoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Cedula",
                table: "Empleados",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_nombre_usuario",
                table: "Empleados",
                column: "nombre_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucion_ArticuloId",
                table: "RentaDevolucion",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucion_ClienteId",
                table: "RentaDevolucion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucion_EmpleadoId",
                table: "RentaDevolucion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucion_fecha_renta",
                table: "RentaDevolucion",
                column: "fecha_renta");

            migrationBuilder.CreateIndex(
                name: "IX_RentaDevolucion_NoRenta",
                table: "RentaDevolucion",
                column: "NoRenta",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElencoArticulo");

            migrationBuilder.DropTable(
                name: "RentaDevolucion");

            migrationBuilder.DropTable(
                name: "Elenco");

            migrationBuilder.DropTable(
                name: "RolesElenco");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "TiposArticulos");
        }
    }
}
