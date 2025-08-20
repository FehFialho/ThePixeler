using ThePixeler.Models;
namespace ThePixeler.UseCases.EditMember;

public record EditMemberPayload(
    User Editor,
    User Edited,
    Role NewRole
);
