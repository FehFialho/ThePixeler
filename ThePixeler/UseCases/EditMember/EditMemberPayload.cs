using ThePixeler.Models;
namespace ThePixeler.UseCases.EditMember;

public record EditMemberPayload(
    Guid EditorID,
    Guid TargetID,
    Role NewRole,
    HttpContext HttpContext
);
