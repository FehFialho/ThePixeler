using ThePixeler.Models;
namespace ThePixeler.UseCases.GetPixels;

public record GetPixelsResponse(
    ICollection<Pixel> Pixels
);