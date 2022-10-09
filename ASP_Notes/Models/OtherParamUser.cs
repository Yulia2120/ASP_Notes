using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Notes.Models
{
    public class OtherParamUser: ParamUser

    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool SeniorManager { get; set; } = false;
        [Required]
        public enumRole EnumRole { get; set; }

     

    }
}
