using Microsoft.EntityFrameworkCore;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.SolicitacaoCompra>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SolicitacaoAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.CondicaoPagamento)
                            .Property(p => p.Valor).HasColumnType("INT").HasColumnName("CondicaoPagamento_Valor").IsRequired();


        }
    }


}
