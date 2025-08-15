namespace ThePixeler.UseCases.EditMember;

public class CreateRoomUseCase
{
    public async Task<Result<EditMemberResponse>> Do(EditMemberPayload payload)
    {
        return Result<EditMemberResponse>.Success(null);
    }
}