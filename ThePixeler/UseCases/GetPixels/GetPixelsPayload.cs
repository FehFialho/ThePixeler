using ThePixeler.Models;
namespace ThePixeler.UseCases.GetPixels;

public record GetPixelsPayload(
    Guid RoomID
);