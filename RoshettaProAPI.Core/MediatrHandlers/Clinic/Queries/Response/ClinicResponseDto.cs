namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response

{
    public class ClinicResponseDto
    {
        public int ClinicID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
