﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prontuarios.Infra.Configuration;

#nullable disable

namespace Prontuarios.Infra.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20230616190940_Prontuarios")]
    partial class Prontuarios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Prontuarios.Domain.Entities.External.CadClientes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CadClientes");
                });

            modelBuilder.Entity("Prontuarios.Domain.Entities.External.CadMedicos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CadMedicos");
                });

            modelBuilder.Entity("Prontuarios.Domain.Entities.Prontuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClienteId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TextoProntuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MedicoId");

                    b.ToTable("Prontuarios");
                });

            modelBuilder.Entity("Prontuarios.Domain.Entities.Prontuario", b =>
                {
                    b.HasOne("Prontuarios.Domain.Entities.External.CadClientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Prontuarios.Domain.Entities.External.CadMedicos", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId");

                    b.Navigation("Cliente");

                    b.Navigation("Medico");
                });
#pragma warning restore 612, 618
        }
    }
}
