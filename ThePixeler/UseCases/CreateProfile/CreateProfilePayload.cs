using System.ComponentModel.DataAnnotations;

namespace ThePixeler.UseCases.CreateProfile;

public record CreateProfilePayload
{
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string UserName { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(8)]
    public string Password { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Image { get; set; }
}