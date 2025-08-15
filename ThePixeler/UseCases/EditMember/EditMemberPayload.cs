using ThePixeler.Models;
namespace ThePixeler.UseCases.EditMember;

public record EditMemberPayload
{
    public User Editor { get; set; }
    public User Edited { get; set; }
    public Role NewRole { get; set; }
}