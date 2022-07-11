
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Model.Mapeamentos
{
    public class LocacaoMapeamento : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("locacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("LocacaoId")
                .IsRequired();

            builder.Property(x => x.ClienteId)
                .HasColumnName("Id_Cliente")
                .IsRequired();

            builder.Property(x => x.FilmeId)
                .HasColumnName("Id_Filme")
                .IsRequired();

            builder.Property(x => x.DataLocacao)
                .HasColumnName("DataLocacao")
                .IsRequired();

            builder.Property(x => x.DataDevolucao)
                .HasColumnName("DataDevolucao");

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Locacoes)
                .HasForeignKey(x => x.FilmeId);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Locacoes)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
