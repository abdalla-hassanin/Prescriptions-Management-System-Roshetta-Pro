using System.Net;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Provides API endpoints for managing prescription records.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all prescription records.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A collection of all prescription records.</returns>
        /// <response code="200">Successfully retrieved the collection of prescription records.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetAllPrescriptions(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllPrescriptionQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific prescription record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the prescription record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The requested prescription record.</returns>
        /// <response code="200">Successfully retrieved the prescription record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        /// <response code="404">The prescription record with the specified ID was not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetPrescriptionById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetPrescriptionByIdQuery { PrescriptionID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new prescription record.
        /// </summary>
        /// <param name="command">The data required to create a new prescription record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The newly created prescription record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Prescription
        ///     {
        ///         "patientID": 1,
        ///         "doctorID": 2,
        ///         "medicationID": 10,
        ///         "dose": "500mg",
        ///         "duration": "7 days",
        ///         "instructions": "Take after meals"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created the prescription record.</response>
        /// <response code="400">The request data is invalid or incomplete.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to create prescription records.</response>
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing prescription record.
        /// </summary>
        /// <param name="id">The unique identifier of the prescription record to update.</param>
        /// <param name="command">The data to update the prescription record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The updated prescription record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Prescription/1
        ///     {
        ///         "prescriptionID": 1,
        ///         "patientID": 1,
        ///         "doctorID": 2,
        ///         "medicationID": 12,
        ///         "dose": "250mg",
        ///         "duration": "5 days",
        ///         "instructions": "Take before meals"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the prescription record.</response>
        /// <response code="400">The request data is invalid or the IDs don't match.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to update prescription records.</response>
        /// <response code="404">The prescription record with the specified ID was not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] UpdatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            if (id != command.PrescriptionID)
            {
                return CreateResponse(ApiResponse<PrescriptionResponse>.Error(HttpStatusCode.BadRequest, "The ID in the URL does not match the ID in the request body."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes a specific prescription record.
        /// </summary>
        /// <param name="id">The unique identifier of the prescription record to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A confirmation of the deletion.</returns>
        /// <response code="200">Successfully deleted the prescription record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to delete prescription records.</response>
        /// <response code="404">The prescription record with the specified ID was not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeletePrescription(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeletePrescriptionCommand { PrescriptionID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
