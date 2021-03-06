﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(TravellContext))]
    [Migration("20200514095412_AddTablas")]
    partial class AddTablas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Pasajero", b =>
                {
                    b.Property<int>("Identificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("Pasajeros");
                });

            modelBuilder.Entity("Entity.Tiquete", b =>
                {
                    b.Property<int>("TiqueteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<int?>("PasajeroIdentificacion")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("TiqueteId");

                    b.HasIndex("PasajeroIdentificacion");

                    b.ToTable("Tiquetes");
                });

            modelBuilder.Entity("Entity.Tiquete", b =>
                {
                    b.HasOne("Entity.Pasajero", null)
                        .WithMany("Tiquetes")
                        .HasForeignKey("PasajeroIdentificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
