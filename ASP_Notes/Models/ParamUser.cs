using System.ComponentModel.DataAnnotations;

namespace ASP_Notes.Models
{
    public class ParamUser
    {
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
