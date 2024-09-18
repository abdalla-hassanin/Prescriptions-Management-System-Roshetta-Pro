using System.Net;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Provides API endpoints for managing medical history records.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalHistoryController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all medical history records.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A collection of all medical history records.</returns>
        /// <response code="200">Successfully retrieved the collection of medical history records.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetAllMedicalHistory(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllMedicalHistoryQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific medical history record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the medical history record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The requested medical history record.</returns>
        /// <response code="200">Successfully retrieved the medical history record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        /// <response code="404">The medical history record with the specified ID was not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetMedicalHistoryById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetMedicalHistoryByIdQuery { MedicalHistoryID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new medical history record.
        /// </summary>
        /// <param name="command">The data required to create a new medical history record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The newly created medical history record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/MedicalHistory
        ///     {
        ///         "diseaseName": "Diabetes",
        ///         "diagnosisDate": "2023-09-01",
        ///         "description": "Chronic disease related to high blood sugar levels."
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created the medical history record.</response>
        /// <response code="400">The request data is invalid or incomplete.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to create medical history records.</response>
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> CreateMedicalHistory([FromBody] CreateMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing medical history record.
        /// </summary>
        /// <param name="id">The unique identifier of the medical history record to update.</param>
        /// <param name="command">The data to update the medical history record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The updated medical history record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/MedicalHistory/1
        ///     {
        ///         "medicalHistoryID": 1,
        ///         "diseaseName": "Diabetes",
        ///         "diagnosisDate": "2023-09-01",
        ///         "description": "Updated description for the chronic disease."
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the medical history record.</response>
        /// <response code="400">The request data is invalid or the IDs don't match.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to update medical history records.</response>
        /// <response code="404">The medical history record with the specified ID was not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateMedicalHistory(int id, [FromBody] UpdateMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            if (id != command.MedicalHistoryID)
            {
                return CreateResponse(ApiResponse<MedicalHistoryResponse>.Error(HttpStatusCode.BadRequest, "Invalid MedicalHistory ID."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes a specific medical history record.
        /// </summary>
        /// <param name="id">The unique identifier of the medical history record to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A confirmation of the deletion.</returns>
        /// <response code="200">Successfully deleted the medical history record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to delete medical history records.</response>
        /// <response code="404">The medical history record with the specified ID was not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeleteMedicalHistory(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteMedicalHistoryCommand { MedicalHistoryID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}
