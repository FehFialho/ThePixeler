namespace ThePixeler.UseCases.PaintPixel;
public record PaintPixelPayload(
    int x,
    int y,
    Guid Painter
);