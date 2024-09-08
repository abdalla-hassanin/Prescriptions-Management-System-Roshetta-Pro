using MediatR;
using Microsoft.AspNetCore.Identity;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Delete
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly ApiResponseHandler _responseHandler;
        private readonly UserManager<IdentityUser> _userManager;

        public DeletePatientHandler(IPatientService patientService, ApiResponseHandler responseHandler,UserManager<IdentityUser> userManager)
        {
            _patientService = patientService;
            _responseHandler = responseHandler;
            _userManager = userManager;

        }

        public async Task<ApiResponse<PatientResponse>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetByIdAsync(request.PatientID, cancellationToken);
            if (patient == null)
            {
                return _responseHandler.NotFound<PatientResponse>("Patient not found.");
            }

            // Find the IdentityUser associated with the doctor's email
            var user = await _userManager.FindByEmailAsync(patient.Email);
            if (user != null)
            {
                // Optional: Remove user roles explicitly (though UserManager.DeleteAsync removes roles automatically)
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any())
                {
                    var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!removeRolesResult.Succeeded)
                    {
                        return _responseHandler.BadRequest<PatientResponse>("Failed to remove roles from user.");
                    }
                }

                // Delete the IdentityUser
                var deleteUserResult = await _userManager.DeleteAsync(user);
                if (!deleteUserResult.Succeeded)
                {
                    return _responseHandler.BadRequest<PatientResponse>("Failed to delete associated user.");
                }
            }

            // Remove the doctor from your system
            await _patientService.RemoveAsync(patient, cancellationToken);
            return _responseHandler.Deleted<PatientResponse>("Patient and associated user deleted successfully.");
        }
    }
}