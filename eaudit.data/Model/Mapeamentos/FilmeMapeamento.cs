using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace eaudit.data.Model.Mapeamentos
{
    public class FilmeMapeamento : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("filmes");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Lancamento);
            builder.HasIndex(x => x.Titulo);

            builder.Property(x => x.Id)
                .HasColumnName("FilmesId")
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ClassificacaoIndicativa)
                .HasColumnName("ClassificacaoIndicativa")
                .IsRequired();

            builder.Property(x => x.Lancamento)
                .HasColumnName("Lancamento")
                .IsRequired();
        }
    }
}
