using System.ComponentModel.DataAnnotations;

namespace SimpleNoteApp.DTOs
{
    public class UpdateNoteDTO
    {
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
    }
}
