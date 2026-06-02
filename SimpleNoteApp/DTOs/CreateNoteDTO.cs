using System.ComponentModel.DataAnnotations;

namespace SimpleNoteApp.DTOs
{
    public class CreateNoteDTO
    {
        [Required]public string Title { get; set; }
        [Required]public string Content { get; set; }
    }
}
