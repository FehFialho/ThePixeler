namespace ThePixeler.UseCases.RemoveMember;

public record RemoveMemberPayload(
    Guid userID, 
    Guid targetID
);