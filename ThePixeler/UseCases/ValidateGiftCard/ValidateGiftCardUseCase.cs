namespace ThePixeler.UseCases.ValidateGiftCard;

public class ValidateGiftCardUseCase
{
    public async Task<Result<ValidateGiftCardResponse>> Do(ValidateGiftCardPayload payload)
    {
        return Result<ValidateGiftCardResponse>.Success(null);
    }
}