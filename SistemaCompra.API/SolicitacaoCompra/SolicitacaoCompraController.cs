using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.RegistrarCompra.Command;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("solicitacao/compra")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult SolicitacaoCompra([FromBody] RegistrarCompraCommand command)
        {
            _mediator.Send(command);
            return StatusCode(201);
        }
    }
}
