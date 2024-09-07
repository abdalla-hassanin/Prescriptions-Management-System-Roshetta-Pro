using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Prescription;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : AppControllerBase
    {
        // GET: api/Prescription
        [HttpGet]
        public async Task<IActionResult> GetAllPrescription(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllPrescriptionQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Prescription/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPrescriptionById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetPrescriptionByIdQuery { PrescriptionID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Prescription
        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Prescription/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] UpdatePrescriptionCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.PrescriptionID)
            {
                return CreateResponse(
                    ApiResponse<PrescriptionResponse>.Error(HttpStatusCode.BadRequest, "Invalid Prescription ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Prescription/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePrescription(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeletePrescriptionCommand { PrescriptionID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}