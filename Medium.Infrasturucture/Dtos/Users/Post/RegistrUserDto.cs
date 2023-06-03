using System.ComponentModel.DataAnnotations;

namespace Medium.Infrasturucture.Dtos.Users.Post
{
    public class RegistrUserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passoword is not same")]
        public string ConfirmPassword { get; set; }
        public string Bio { get; set; }
    }
}
