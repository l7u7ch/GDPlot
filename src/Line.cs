using System.Linq;
using Godot;

public partial class Line : Element
{
    public Color LineColor = Colors.Red;
    public Color MarkerColor = Colors.Red;
    public int LineWeight = 2;
    public int MarkerSize = 4;

    public override void _Draw()
    {
        Normalize()
            .Aggregate(
                (prev, curr) =>
                {
                    DrawLine(prev, curr, LineColor, LineWeight);
                    return curr;
                }
            );

        Normalize().ToList().ForEach(Point => DrawCircle(position: Point, radius: MarkerSize, color: MarkerColor));
    }
}
