using FluentValidation;
using SistemaCompra.Application.RegistrarCompra.Command;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Collections.Generic;

namespace SistemaCompra.Application.Validators
{
    public class RegistrarCompraCommandValidator : AbstractValidator<RegistrarCompraCommand>
    {
        public RegistrarCompraCommandValidator()
        {
            RuleFor(x => x.NomeFornecedor)
                .NotNull()
                .NotEmpty()
                .MaximumLength(55)
                .WithMessage("Tamanho maximo do campo nome fornecedor é de 55 caracteres");

            RuleFor(x => x.UsuarioSolicitante)
                .NotNull()
                .NotEmpty()
                .MaximumLength(55)
                .WithMessage("Tamanho maximo do campo nome Solicitante é de 55 caracteres");


        }

            //RuleFor(x => x.TotalGeral)
            //    .
        //public List<Item> Itens { get; set; }
        //public int TotalGeral { get; set; }
    
    }
}
