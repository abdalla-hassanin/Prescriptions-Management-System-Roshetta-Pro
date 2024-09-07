using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Medication;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : AppControllerBase
    {
        // GET: api/Medication
        [HttpGet]
        public async Task<IActionResult> GetAllMedication(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllMedicationQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Medication/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMedicationById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetMedicationByIdQuery { MedicationID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Medication
        [HttpPost]
        public async Task<IActionResult> CreateMedication([FromBody] CreateMedicationCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Medication/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMedication(int id, [FromBody] UpdateMedicationCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.MedicationID)
            {
                return CreateResponse(
                    ApiResponse<MedicationResponse>.Error(HttpStatusCode.BadRequest, "Invalid Medication ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Medication/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedication(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteMedicationCommand { MedicationID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}