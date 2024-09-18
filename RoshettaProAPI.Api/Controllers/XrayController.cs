using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Xray;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Delete;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetAll;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetById;

namespace RoshettaProAPI.Api.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing X-ray records.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class XrayController : AppControllerBase
    {
        /// <summary>
        /// Retrieves all X-ray records.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A collection of all X-ray records.</returns>
        /// <response code="200">Successfully retrieved the collection of X-ray records.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetAllXray(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetAllXrayQuery(), cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Retrieves a specific X-ray record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the X-ray record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The requested X-ray record.</returns>
        /// <response code="200">Successfully retrieved the X-ray record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to access this resource.</response>
        /// <response code="404">The X-ray record with the specified ID was not found.</response>
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<IActionResult> GetXrayById(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetXrayByIdQuery { XrayID = id }, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Creates a new X-ray record.
        /// </summary>
        /// <param name="command">The data required to create a new X-ray record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The newly created X-ray record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Xray
        ///     {
        ///         "patientID": 1,
        ///         "doctorID": 2,
        ///         "dateTaken": "2023-09-17T10:30:00Z",
        ///         "xrayImageURL": "https://example.com/xrays/chest_001.jpg",
        ///         "labName": "Central Hospital Radiology",
        ///         "xrayType": "Chest X-ray",
        ///         "notes": "No significant abnormalities detected."
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created the X-ray record.</response>
        /// <response code="400">The request data is invalid or incomplete.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to create X-ray records.</response>
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> CreateXray([FromBody] CreateXrayCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Updates an existing X-ray record.
        /// </summary>
        /// <param name="id">The unique identifier of the X-ray record to update.</param>
        /// <param name="command">The data to update the X-ray record.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>The updated X-ray record.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Xray/1
        ///     {
        ///         "xrayID": 1,
        ///         "patientID": 1,
        ///         "doctorID": 2,
        ///         "dateTaken": "2023-09-17T10:30:00Z",
        ///         "xrayImageURL": "https://example.com/xrays/chest_001_updated.jpg",
        ///         "labName": "Central Hospital Radiology",
        ///         "xrayType": "Chest X-ray",
        ///         "notes": "Upon review, minor abnormality detected in lower right lobe."
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Successfully updated the X-ray record.</response>
        /// <response code="400">The request data is invalid or the IDs don't match.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to update X-ray records.</response>
        /// <response code="404">The X-ray record with the specified ID was not found.</response>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateXray(int id, [FromBody] UpdateXrayCommand command, CancellationToken cancellationToken)
        {
            if (id != command.XrayID)
            {
                return CreateResponse(ApiResponse<XrayResponse>.Error(HttpStatusCode.BadRequest, "The ID in the URL does not match the ID in the request body."));
            }

            var response = await Mediator.Send(command, cancellationToken);
            return CreateResponse(response);
        }

        /// <summary>
        /// Deletes a specific X-ray record.
        /// </summary>
        /// <param name="id">The unique identifier of the X-ray record to delete.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A confirmation of the deletion.</returns>
        /// <response code="200">Successfully deleted the X-ray record.</response>
        /// <response code="401">Authentication failed. User is not authenticated.</response>
        /// <response code="403">Authorization failed. User does not have permission to delete X-ray records.</response>
        /// <response code="404">The X-ray record with the specified ID was not found.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeleteXray(int id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new DeleteXrayCommand { XrayID = id }, cancellationToken);
            return CreateResponse(response);
        }
    }
}