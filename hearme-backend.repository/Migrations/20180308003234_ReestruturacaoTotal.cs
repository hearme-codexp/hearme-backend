using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace hearmebackend.repository.Migrations
{
    public partial class ReestruturacaoTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Generos_GeneroId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_GrausDeficiencias_GrauDeficienciaId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "GrausDeficiencias");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_GeneroId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_GrauDeficienciaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "GrauDeficienciaId",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrauDeficiencia",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DuracaoVibracoes = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAlertasDomain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlertaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    DataHorarioAlerta = table.Column<DateTime>(nullable: false),
                    Localizacao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlertasDomain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAlertasDomain_Alerta_AlertaId",
                        column: x => x.AlertaId,
                        principalTable: "Alerta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoAlertasDomain_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlertasDomain_AlertaId",
                table: "HistoricoAlertasDomain",
                column: "AlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlertasDomain_ClienteId",
                table: "HistoricoAlertasDomain",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAlertasDomain");

            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "GrauDeficiencia",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrauDeficienciaId",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrausDeficiencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrausDeficiencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_GeneroId",
                table: "Clientes",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_GrauDeficienciaId",
                table: "Clientes",
                column: "GrauDeficienciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Generos_GeneroId",
                table: "Clientes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_GrausDeficiencias_GrauDeficienciaId",
                table: "Clientes",
                column: "GrauDeficienciaId",
                principalTable: "GrausDeficiencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
