using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application.RegistrarCompra.Command
{
    public class RegistrarCompraCommandHandler : IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solictacao = new SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);


            foreach (var item in request.Itens)
            {
                //var produto = _solicitacaoCompraRepository.ObterProdutoPorId(item.Produto.Id);
                var produto = new ProdutoAgg.Produto("produto001", "desc", Categoria.Madeira.ToString(), 400);
                solictacao.AdicionarItem(produto, item.Qtde);
            }

            solictacao.RegistrarCompra(solictacao.Itens);
            solictacao.ValidandoValorGeral(request.TotalGeral);

            _solicitacaoCompraRepository.RegistrarCompra(solictacao);

            return Task.FromResult(true);

        }
    }
}
