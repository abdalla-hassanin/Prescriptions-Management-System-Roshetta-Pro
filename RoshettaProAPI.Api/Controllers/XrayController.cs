using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XrayController : AppControllerBase
    {
        // GET: api/Prescription
        [HttpGet]
        public async Task<IActionResult> GetAllXray(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllXrayQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Prescription/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetXrayById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetXrayByIdQuery { XrayID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Prescription
        [HttpPost]
        public async Task<IActionResult> CreateXray([FromBody] CreateXrayCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Prescription/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateXray(int id, [FromBody] UpdateXrayCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.XrayID)
            {
                return CreateResponse(
                    ApiResponse<XrayResponse>.Error(HttpStatusCode.BadRequest, "Invalid Prescription ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Prescription/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteXray(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteXrayCommand { XrayID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}