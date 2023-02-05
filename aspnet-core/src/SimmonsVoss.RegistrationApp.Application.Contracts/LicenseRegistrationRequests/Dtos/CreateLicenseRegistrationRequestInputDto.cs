using System.ComponentModel.DataAnnotations;

namespace SimmonsVoss.RegistrationApp.LicenseRegistrationRequests.Dtos
{
    public class CreateLicenseRegistrationRequestInputDto
    {
        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        public string ComapnyName { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(250)]
        public string ContactPerson { get; set; }

        [Required]
        [StringLength(100)]
        public string LicenseKey { get; set; }
    }
}
