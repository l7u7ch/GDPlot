using System.Linq;
using Godot;

[Tool]
public partial class Scatter : Element
{
    public Color MarkerColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int MarkerSize = 4;

    public override void _Draw()
    {
        NormalizedX
            .Zip(NormalizedY, (X, Y) => new Vector2(X, Y))
            .ToList()
            .ForEach(Point => DrawCircle(position: Point, radius: MarkerSize, color: MarkerColor));
    }
}

// using Godot.Collections;

// DrawLine(new Vector2(0, 0), new Vector2(0, GetRect().Size.Y), Colors.Red);
// DrawLine(new Vector2(0, 0), new Vector2(GetRect().Size.X, 0), Colors.Red);
// DrawLine(new Vector2(0, GetRect().Size.Y), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Red);
// DrawLine(new Vector2(GetRect().Size.X, 0), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Red);

// NormalizedX
//     .Zip(NormalizedY, (X, Y) => new Vector2(X, Y))
//     .ToList()
//     .ForEach(Point => DrawCircle(position: Point, radius: MarkerSize, color: MarkerColor));
