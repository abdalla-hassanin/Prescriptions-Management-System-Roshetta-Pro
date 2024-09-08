using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Entities.Auth;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Create
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, ApiResponse<PatientResponse>>
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;


        public CreatePatientHandler(IPatientService patientService, IMapper mapper,
            ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager, IConfiguration configuration,
            IEmailService emailService
        )
        {
            _patientService = patientService;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<ApiResponse<PatientResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Data.Entities.Patient>(request);
            var existingUserByEmail = await _userManager.FindByEmailAsync(patient.Email);
            if (existingUserByEmail != null)
                return _responseHandler.BadRequest<PatientResponse>("Email is already registered!");
            
            await _patientService.AddAsync(patient, cancellationToken);

            // Create User with unique username
            var userName = $"{patient.FirstName}{patient.LastName}{Guid.NewGuid().ToString().Substring(0, 6)}";
            var user = new IdentityUser
            {
                UserName = userName,
                Email = patient.Email,
            };
            var createUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createUserResult.Succeeded)
                return _responseHandler.BadRequest<PatientResponse>(string.Join(", ",
                    createUserResult.Errors.Select(e => e.Description)));

            // Assign role to user
            var addRoleResult = await _userManager.AddToRoleAsync(user, "Patient");
            if (!addRoleResult.Succeeded)
                return _responseHandler.BadRequest<PatientResponse>(string.Join(", ",
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


            var patientResponse = _mapper.Map<PatientResponse>(patient);
            return _responseHandler.Created(patientResponse);
        }
        private string GenerateEmailConfirmationLink(string userId, string token)
        {
            var baseUrl = _configuration["AppUrl"];
            var encodedToken = Uri.EscapeDataString(token); // Encode the token
            return $"{baseUrl}/api/auth/confirm-email?userId={userId}&token={encodedToken}";
        }

    }
}