using System;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.Dtos
{
    public class LicenseRegistrationRequestDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string ComapnyName { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        //public string LicenseKey { get; set; }
    }
}
