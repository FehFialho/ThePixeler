namespace ThePixeler.UseCases.InviteMember;

public record InviteMemberPayload(
    Guid Sender,
    Guid Receiver
); 