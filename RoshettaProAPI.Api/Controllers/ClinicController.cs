// using System.Net;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using RoshettaProAPI.Api.Base;
// using RoshettaProAPI.Core.Base.ApiResponse;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
// using RoshettaProAPI.Data.Entities;
//
// namespace RoshettaProAPI.Api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ClinicController : AppControllerBase
//     {
//         // GET: api/Clinic
//         [HttpGet]
//         public async Task<IActionResult> GetAllClinics(CancellationToken cancellationToken)
//         {
//             var response = await Mediator.Send( new GetAllClinicsQuery(), cancellationToken);
//             return CreateResponse(response);
//         }
//
//         // GET: api/Clinic/{id}
//         [HttpGet("{id:int}")]
//         public async Task<IActionResult> GetClinicById(int id, CancellationToken cancellationToken)
//         {
//             var response = await Mediator.Send(new GetClinicByIdQuery { ClinicID = id }, cancellationToken);
//             return CreateResponse(response);
//         }
//
//         // POST: api/Clinic
//         [HttpPost]
//         public async Task<IActionResult> CreateClinic([FromBody] CreateClinicCommand command, CancellationToken cancellationToken)
//         {
//             var response = await Mediator.Send(command, cancellationToken);
//             return CreateResponse(response);
//         }
//
//         // PUT: api/Clinic/{id}
//         [HttpPut("{id:int}")]
//         public async Task<IActionResult> UpdateClinic(int id, [FromBody] UpdateClinicCommand command, CancellationToken cancellationToken)
//         {
//             if (id != command.ClinicID)
//             {
//                 return CreateResponse(ApiResponse<ClinicResponseDto>.Error(HttpStatusCode.BadRequest, "Invalid Clinic ID."));
//             }
//
//             var response = await Mediator.Send(command, cancellationToken);
//             return CreateResponse(response);
//         }
//
//         // DELETE: api/Clinic/{id}
//         [HttpDelete("{id:int}")]
//         public async Task<IActionResult> DeleteClinic(int id, CancellationToken cancellationToken)
//         {
//             var response = await Mediator.Send(new DeleteClinicCommand { ClinicID = id }, cancellationToken);
//             return CreateResponse(response);
//         }
//     }
// }
