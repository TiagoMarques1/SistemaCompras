using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Fornecedor
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<NomeFornecedor>
    {
        public void Configure(EntityTypeBuilder<NomeFornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(x => x.Id);
        }
    }
}
