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
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("TURMA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME");

            builder.Property(t => t.Numero)
                .HasColumnName("NUMERO")
                .IsRequired();

            builder.Property(t => t.AnoLetivo)
                .HasColumnName("ANO_LETIVO")
                .IsRequired();

            builder.Property(t => t.Nivel)
                .HasColumnName("NIVEL")
                .IsRequired();

        }
    }
}
