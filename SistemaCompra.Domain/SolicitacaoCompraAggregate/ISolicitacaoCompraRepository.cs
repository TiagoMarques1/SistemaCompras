using SistemaCompra.Domain.ProdutoAggregate;
using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        Produto ObterProdutoPorId(Guid id);
        void RegistrarCompra(SolicitacaoCompra entity);
        
    }
}
