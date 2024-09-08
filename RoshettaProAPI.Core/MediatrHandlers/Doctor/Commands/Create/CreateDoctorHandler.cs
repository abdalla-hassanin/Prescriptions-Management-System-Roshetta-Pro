using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Entities.Auth;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Create
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, ApiResponse<DoctorResponse>>
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;


        public CreateDoctorHandler(IDoctorService doctorService, IMapper mapper,
            ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager, IConfiguration configuration,
            IEmailService emailService
        )
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<ApiResponse<DoctorResponse>> Handle(CreateDoctorCommand request,
            CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Data.Entities.Doctor>(request);

            var existingUserByEmail = await _userManager.FindByEmailAsync(doctor.Email);
            if (existingUserByEmail != null)
                return _responseHandler.BadRequest<DoctorResponse>("Email is already registered!");

            await _doctorService.AddAsync(doctor, cancellationToken);

            // Create User with unique username
            var userName = $"{doctor.FirstName}{doctor.LastName}{Guid.NewGuid().ToString().Substring(0, 6)}";
            var user = new IdentityUser
            {
                UserName = userName,
                Email = doctor.Email,
            };
            var createUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createUserResult.Succeeded)
                return _responseHandler.BadRequest<DoctorResponse>(string.Join(", ",
                    createUserResult.Errors.Select(e => e.Description)));

            // Assign role to user
            var addRoleResult = await _userManager.AddToRoleAsync(user, "Doctor");
            if (!addRoleResult.Succeeded)
                return _responseHandler.BadRequest<DoctorResponse>(string.Join(", ",
                    addRoleResult.Errors.Select(e => e.Description)));

            // Generate email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = GenerateEmailConfirmationLink(user.Id, token);

            // Send email confirmation
            await _emailService.SendAsync(new EmailModel
            {
                To = user.Email,
                Subject = "Email Confirmation",
                Body = $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>."
            });


            var doctorResponse = _mapper.Map<DoctorResponse>(doctor);
            return _responseHandler.Created(doctorResponse);
        }

        private string GenerateEmailConfirmationLink(string userId, string token)
        {
            var baseUrl = _configuration["AppUrl"];
            var encodedToken = Uri.EscapeDataString(token); // Encode the token
            return $"{baseUrl}/api/auth/confirm-email?userId={userId}&token={encodedToken}";
        }
    }
}