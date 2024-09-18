using System.Net;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Provides API endpoints for managing medications.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all medication records.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A collection of all medication records.</returns>
        /// <response code="200">Successfully retrieved the collection of medication records.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAllMedication(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllMedicationQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific medication record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the medication record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The requested medication record.</returns>
        /// <response code="200">Successfully retrieved the medication record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        /// <response code="404">The medication record with the specified ID was not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetMedicationById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetMedicationByIdQuery { MedicationID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new medication record.
        /// </summary>
        /// <param name="command">The data required to create a new medication record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The newly created medication record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Medication
        ///     {
        ///         "name": "Paracetamol",
        ///         "description": "Pain reliever and fever reducer",
        ///         "sideEffects": "Nausea, Vomiting",
        ///         "medicationForm": "Tablet"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created the medication record.</response>
        /// <response code="400">The request data is invalid or incomplete.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to create medication records.</response>
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> CreateMedication([FromBody] CreateMedicationCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing medication record.
        /// </summary>
        /// <param name="id">The unique identifier of the medication record to update.</param>
        /// <param name="command">The data to update the medication record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The updated medication record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Medication/1
        ///     {
        ///         "medicationID": 1,
        ///         "name": "Paracetamol",
        ///         "description": "Pain reliever and fever reducer",
        ///         "sideEffects": "Mild Nausea",
        ///         "medicationForm": "Tablet"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the medication record.</response>
        /// <response code="400">The request data is invalid or the IDs don't match.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to update medication records.</response>
        /// <response code="404">The medication record with the specified ID was not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateMedication(int id, [FromBody] UpdateMedicationCommand command, CancellationToken cancellationToken)
        {
            if (id != command.MedicationID)
            {
                return CreateResponse(ApiResponse<MedicationResponse>.Error(HttpStatusCode.BadRequest, "Invalid Medication ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes a specific medication record.
        /// </summary>
        /// <param name="id">The unique identifier of the medication record to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A confirmation of the deletion.</returns>
        /// <response code="200">Successfully deleted the medication record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to delete medication records.</response>
        /// <response code="404">The medication record with the specified ID was not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeleteMedication(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteMedicationCommand { MedicationID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
