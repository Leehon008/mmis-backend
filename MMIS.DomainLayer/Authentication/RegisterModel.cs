using System.ComponentModel.DataAnnotations;

namespace MMIS.DomainLayer.Authentication
{
    public class RegisterModel
    {
        //[EmailAddress]
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PlantId { get; set; }

        public string Usergroup { get; set; }

        public string Usertype { get; set; }
    }
    public class AdminRegisterModel
    {
        //[EmailAddress]
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string RegKey { get; set; }
    }
}
