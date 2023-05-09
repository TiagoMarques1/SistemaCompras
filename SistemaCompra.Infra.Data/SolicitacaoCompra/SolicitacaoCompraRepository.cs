using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Linq;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;


namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public ProdutoAgg.Produto ObterProdutoPorId(Guid id)
        {
            return context.Set<ProdutoAgg.Produto>().Where(c => c.Id == id).FirstOrDefault();

        }

        public void RegistrarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra entity)
        {
            context.Set<SolicitacaoAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}
