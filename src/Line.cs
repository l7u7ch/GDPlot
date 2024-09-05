using System.Linq;
using Godot;

public partial class Line : Element
{
    public Color LineColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public Color MarkerColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int LineWeight = 2;
    public int MarkerSize = 4;

    public override void _Draw()
    {
        if (Points.Count < 2)
        {
            return;
        }

        // Line を描画する
        Normalize()
            .Aggregate(
                (prev, curr) =>
                {
                    DrawLine(prev, curr, LineColor, LineWeight);
                    return curr;
                }
            );

        // Marker を描画する
        Normalize().ToList().ForEach(Point => DrawCircle(position: Point, radius: MarkerSize, color: MarkerColor));
    }
}
