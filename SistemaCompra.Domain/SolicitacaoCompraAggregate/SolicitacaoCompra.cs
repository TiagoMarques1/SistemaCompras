﻿using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }

        [ForeignKey("NomeUsuario")]
        public Guid IdUsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }

        [ForeignKey("NomeFornecedor")]
        public Guid IdNomeFornecedor { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public IList<Item> Itens { get; private set; }

        [ForeignKey("IdItens")]
        public Guid IdItens { get; private set; }

        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            CondicaoPagamento = new CondicaoPagamento();

            Itens = new List<Item>();
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens.Count() == 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            Itens = Itens;
        }

        public void ValidandoValorGeral(int totalGeral)
        {
            TotalGeral = new Money(totalGeral);
            if (totalGeral > 5000)
            {
                CondicaoPagamento.CondicaoParaPagamento(30);
            }
        }

    }
}
