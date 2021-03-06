﻿// <auto-generated />
using hearme_backend.domain.DataTypes;
using hearme_backend.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace hearmebackend.repository.Migrations
{
    [DbContext(typeof(HearMeContext))]
    partial class HearMeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("hearme_backend.domain.Entities.Alerta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TipoAlertas");

                    b.HasKey("Id");

                    b.ToTable("Alertas");
                });

            modelBuilder.Entity("hearme_backend.domain.Entities.ClientesDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("Genero");

                    b.Property<int>("GrauDeficiencia");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("hearme_backend.domain.Entities.HistoricoAlertasDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlertaId");

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("DataHorarioAlerta");

                    b.Property<float>("Lat");

                    b.Property<float>("Lon");

                    b.HasKey("Id");

                    b.HasIndex("AlertaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Historico");
                });

            modelBuilder.Entity("hearme_backend.domain.Entities.UsuarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Token")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("hearme_backend.domain.Entities.ClientesDomain", b =>
                {
                    b.HasOne("hearme_backend.domain.Entities.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hearme_backend.domain.Entities.HistoricoAlertasDomain", b =>
                {
                    b.HasOne("hearme_backend.domain.Entities.Alerta", "Alerta")
                        .WithMany("HistoricosAlertasDomain")
                        .HasForeignKey("AlertaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hearme_backend.domain.Entities.ClientesDomain", "Cliente")
                        .WithMany("HistoricosAlertasDomain")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
