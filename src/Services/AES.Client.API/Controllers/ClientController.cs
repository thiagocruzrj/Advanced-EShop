using AES.Clients.API.Application.Commands;
using AES.Core.Controllers;
using AES.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AES.Clients.API.Controllers
{
    public class ClientController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clients")]
        public async Task<ActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommand(
                new RegisterClientCommand(Guid.NewGuid(), "Thiago", "thiago@gmail.com", "47842624070"));

            return CustomResponse(result);
        }
    }
}