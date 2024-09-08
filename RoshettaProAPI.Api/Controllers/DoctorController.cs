using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Doctor;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : AppControllerBase
    {
        // GET: api/Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
            return CreateResponse(response);
        }

        // GET: api/Doctor/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetDoctorByIdQuery { DoctorID = id }, cancellationToken);
            return CreateResponse(response);
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command,
            CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // PUT: api/Doctor/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorCommand command,
            CancellationToken cancellationToken)
        {
            if (id != command.DoctorID)
            {
                return CreateResponse(
                    ApiResponse<DoctorResponse>.Error(HttpStatusCode.BadRequest, "Invalid Doctor ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        // DELETE: api/Doctor/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDoctor(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteDoctorCommand { DoctorID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}