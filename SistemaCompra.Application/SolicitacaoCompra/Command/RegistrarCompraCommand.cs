using MediatR;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.RegistrarCompra.Command
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get;  set; }
        public string NomeFornecedor { get;  set; }
        public List<Item> Itens { get;  set; }
        public int TotalGeral { get;  set; }
    }
}
