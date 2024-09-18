using System.Net;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Handles API endpoints related to Patient operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all patients.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin".
        /// </remarks>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>List of patients.</returns>
        /// <response code="200">Returns the list of patients.</response>
        /// <response code="403">Unauthorized access if the user does not have the required role.</response>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPatients(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllPatientsQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific patient by their ID.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin", "Doctor", or "Patient".
        /// </remarks>
        /// <param name="id">The ID of the patient to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Details of the specified patient.</returns>
        /// <response code="200">Returns the patient details.</response>
        /// <response code="404">If the patient is not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetPatientById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetPatientByIdQuery { PatientID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The details of the patient to create.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the patient creation.</returns>
        /// <response code="201">Patient created successfully.</response>
        /// <response code="400">If the patient data is invalid or email is already registered.</response>
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing patient.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin" or "Patient".
        /// </remarks>
        /// <param name="id">The ID of the patient to update.</param>
        /// <param name="command">The updated patient details.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the patient update.</returns>
        /// <response code="200">Patient updated successfully.</response>
        /// <response code="400">If the patient ID in the URL does not match the request body or if the update data is invalid.</response>
        /// <response code="404">If the patient is not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            if (id != command.PatientID)
            {
                return CreateResponse(ApiResponse<PatientResponse>.Error(HttpStatusCode.BadRequest, "Invalid Patient ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes an existing patient.
        /// </summary>
        /// <remarks>
        /// Requires the role "Admin" or "Patient".
        /// </remarks>
        /// <param name="id">The ID of the patient to delete.</param>
        /// <param name="cancellationToken">Cancellation token for the request.</param>
        /// <returns>Confirmation of the patient deletion.</returns>
        /// <response code="200">Patient deleted successfully.</response>
        /// <response code="404">If the patient is not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeletePatientCommand { PatientID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
