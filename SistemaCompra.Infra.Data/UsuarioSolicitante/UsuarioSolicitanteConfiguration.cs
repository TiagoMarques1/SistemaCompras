using Microsoft.EntityFrameworkCore;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.UsuarioSolicitante
{
    public class UsuarioSolicitanteConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.UsuarioSolicitante>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SolicitacaoAgg.UsuarioSolicitante> builder)
        {
            builder.ToTable("UsuarioSolicitante");
            builder.HasKey(x => x.Id);
        }
    }
}
