using System.ComponentModel.DataAnnotations;

namespace ASP_Notes.Models
{
    public class Note
    {
        
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
      

    }

}
