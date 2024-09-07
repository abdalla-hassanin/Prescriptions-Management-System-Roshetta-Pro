using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : AppControllerBase
    {
        // GET: api/Medication
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalHistory(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllMedicalHistoryQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Medication/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMedicalHistoryById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetMedicalHistoryByIdQuery { MedicalHistoryID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Medication
        [HttpPost]
        public async Task<IActionResult> CreateMedicalHistory([FromBody] CreateMedicalHistoryCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Medication/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMedicalHistory(int id, [FromBody] UpdateMedicalHistoryCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.MedicalHistoryID)
            {
                return CreateResponse(
                    ApiResponse<MedicalHistoryResponse>.Error(HttpStatusCode.BadRequest, "Invalid Medication ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Medication/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedicalHistory(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteMedicalHistoryCommand { MedicalHistoryID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}