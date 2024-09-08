using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Patient;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : AppControllerBase
    {
        // GET: api/Medication
        [HttpGet]
        public async Task<IActionResult> GetAllPatients(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send( new GetAllPatientsQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Medication/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetPatientByIdQuery { PatientID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Medication
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Medication/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            if (id != command.PatientID)
            {
                return CreateResponse(ApiResponse<PatientResponse>.Error(HttpStatusCode.BadRequest, "Invalid Medication ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Medication/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeletePatientCommand { PatientID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
