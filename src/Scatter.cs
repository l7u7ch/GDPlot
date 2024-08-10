using System.Linq;
using Godot;

public partial class Scatter : Element
{
    public Color MarkerColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int MarkerSize = 4;

    public override void _Draw()
    {
        Normalize().ToList().ForEach(Point => DrawCircle(position: Point, radius: MarkerSize, color: MarkerColor));
    }
}
