namespace ThePixeler.UseCases.ValidateGiftCard;

public record ValidateGiftCardPayload(
    int userId,
    int code,
    int subscriptionID
);