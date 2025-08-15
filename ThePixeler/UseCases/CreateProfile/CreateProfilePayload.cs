using System.Reflection;

namespace ThePixeler.UseCase.CreateProfile;

public record CreateProfilePayload
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
}