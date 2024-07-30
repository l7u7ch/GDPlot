using System.Linq;
using Godot;

public partial class Bar : Element
{
    Color BarColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    int BarWeight = 10;

    public override void _Draw()
    {
        NormalizedX
            .Zip(NormalizedY, (X, Y) => new Vector2(X, Y))
            .ToList()
            .ForEach(Point =>
            {
                DrawRect(new Rect2(Point.X - (BarWeight / 2), Size.Y, BarWeight, Point.Y - Size.Y), Colors.Red);
            });
    }
}
