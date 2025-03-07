﻿// <auto-generated />
using System;
using CursoApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250203215009_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("CPF");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ALUNO", (string)null);
                });

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Matricula", b =>
                {
                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TURMA_ID");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ALUNO_ID");

                    b.HasKey("TurmaId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("MATRICULA", (string)null);
                });

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("AnoLetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ANO_LETIVO");

                    b.Property<int>("Nivel")
                        .HasColumnType("int")
                        .HasColumnName("NIVEL");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NUMERO");

                    b.HasKey("Id");

                    b.ToTable("TURMA", (string)null);
                });

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Matricula", b =>
                {
                    b.HasOne("CursoApp.Domain.Models.Entities.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CursoApp.Domain.Models.Entities.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("CursoApp.Domain.Models.Entities.Turma", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
