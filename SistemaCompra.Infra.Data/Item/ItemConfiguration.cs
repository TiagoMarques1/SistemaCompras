using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Item
{
    public class ItemConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Qtde).HasColumnType("INT").IsRequired();

            builder.OwnsOne(p => p.Produto)
                            .Property(p => p.Preco).HasColumnName("Categoria").HasColumnType("MONEY").IsRequired();

            builder.OwnsOne(p => p.Produto)
                            .Property(p => p.Categoria).HasConversion<string>().HasColumnName("Categoria");

            builder.OwnsOne(p => p.Produto)
                            .Property(p => p.Situacao).HasConversion<string>().HasColumnName("Situacao");

            builder.OwnsOne(p => p.Produto)
                            .Property(p => p.Descricao).HasColumnType("VARCHAR(60)").HasColumnName("Descricao").IsRequired();

            builder.OwnsOne(p => p.Produto)
                            .Property(p => p.Nome).HasColumnType("VARCHAR(60)").HasColumnName("Nome").IsRequired();
        }
    }
}
