using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eaudit.data.Model.Mapeamentos
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Cpf);
            builder.HasIndex(x => x.Nome);

            builder.Property(x => x.Id)
                .HasColumnName("ClienteId")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();
        }
    }
}
