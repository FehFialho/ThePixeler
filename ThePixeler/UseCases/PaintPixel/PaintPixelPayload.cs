using System.Drawing;

namespace ThePixeler.UseCases.PaintPixel;
public record PaintPixelPayload(
    int x,
    int y,
    int R,
    int G,
    int B,
    Guid PainterID,
    int roomID
);