using System.Net;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Handles API endpoints related to Doctor operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all doctors.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin".
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>List of doctors.</returns>
        /// <response code="200">Returns the list of doctors.</response>
        /// <response code="403">Unauthorized access if the user does not have the required role.</response>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoctors(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific doctor by their ID.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin", "Doctor", or "Patient".
        /// </remarks>
        /// <param name="id">The ID of the doctor to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Details of the specified doctor.</returns>
        /// <response code="200">Returns the doctor details.</response>
        /// <response code="404">If the doctor is not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetDoctorById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetDoctorByIdQuery { DoctorID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new doctor.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The details of the doctor to create.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the doctor creation.</returns>
        /// <response code="201">Doctor created successfully.</response>
        /// <response code="400">If the doctor data is invalid or email is already registered.</response>
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing doctor.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin" or "Doctor".
        /// </remarks>
        /// <param name="id">The ID of the doctor to update.</param>
        /// <param name="command">The updated doctor details.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the doctor update.</returns>
        /// <response code="200">Doctor updated successfully.</response>
        /// <response code="400">If the doctor ID in the URL does not match the request body or if the update data is invalid.</response>
        /// <response code="404">If the doctor is not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            if (id != command.DoctorID)
            {
                return CreateResponse(ApiResponse<DoctorResponse>.Error(HttpStatusCode.BadRequest, "Invalid Doctor ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes an existing doctor.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin" or "Doctor".
        /// </remarks>
        /// <param name="id">The ID of the doctor to delete.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the doctor deletion.</returns>
        /// <response code="200">Doctor deleted successfully.</response>
        /// <response code="404">If the doctor is not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeleteDoctor(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteDoctorCommand { DoctorID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
