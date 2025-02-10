using CursoApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Infra.Data.Mappigns
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("MATRICULA");
            builder.HasKey(m => new { m.TurmaId, m.AlunoId }); //chave composta

            builder.Property(m => m.TurmaId)
                .HasColumnName("TURMA_ID")
                .IsRequired();

            builder.Property(m => m.AlunoId)
                .HasColumnName("ALUNO_ID")
                .IsRequired();

            builder.HasOne(m => m.Turma)
                .WithMany(m => m.Matriculas)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Aluno)
                .WithMany(m => m.Matriculas)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
