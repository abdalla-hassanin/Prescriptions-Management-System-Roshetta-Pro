using MediatR;
using Microsoft.AspNetCore.Identity;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Delete
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly ApiResponseHandler _responseHandler;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteDoctorHandler(IDoctorService doctorService, ApiResponseHandler responseHandler,UserManager<IdentityUser> userManager)
        {
            _doctorService = doctorService;
            _responseHandler = responseHandler;
            _userManager = userManager;

        }

        public async Task<ApiResponse<DoctorResponse>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorService.GetByIdAsync(request.DoctorID, cancellationToken);
            if (doctor == null)
            {
                return _responseHandler.NotFound<DoctorResponse>("Doctor not found.");
            }
            
            // Find the IdentityUser associated with the doctor's email
            var user = await _userManager.FindByEmailAsync(doctor.Email);
            if (user != null)
            {
                // Optional: Remove user roles explicitly (though UserManager.DeleteAsync removes roles automatically)
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any())
                {
                    var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!removeRolesResult.Succeeded)
                    {
                        return _responseHandler.BadRequest<DoctorResponse>("Failed to remove roles from user.");
                    }
                }

                // Delete the IdentityUser
                var deleteUserResult = await _userManager.DeleteAsync(user);
                if (!deleteUserResult.Succeeded)
                {
                    return _responseHandler.BadRequest<DoctorResponse>("Failed to delete associated user.");
                }
            }

            // Remove the doctor from your system
            await _doctorService.RemoveAsync(doctor, cancellationToken);
            return _responseHandler.Deleted<DoctorResponse>("Doctor and associated user deleted successfully.");
        }
    }
}