using ThePixeler.Models;
namespace ThePixeler.UseCases.EditMember;

public record EditMemberPayload(
    //arrunmar
    User Editor,
    User Edited,
    Role NewRole
);
