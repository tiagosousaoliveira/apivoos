using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassagensServices;

namespace PassagensApi.Controllers
{
    [Route("api/agencia/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VooController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ObtemPassagensQuery());
            return Ok(response);
        }
    }
}
