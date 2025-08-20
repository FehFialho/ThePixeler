using System.Drawing;

namespace ThePixeler.UseCases.PaintPixel;
public record PaintPixelPayload(
    int x,
    int y,
    Color color,
    Guid Painter,
    Guid roomID
);