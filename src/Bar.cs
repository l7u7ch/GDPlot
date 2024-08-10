using System.Linq;
using Godot;

public partial class Bar : Element
{
    public Color BarColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int BarWeight = 10;

    public override void _Draw()
    {
        Normalize()
            .ToList()
            .ForEach(Point =>
            {
                DrawRect(new Rect2(Point.X - (BarWeight / 2), Size.Y, BarWeight, Point.Y - Size.Y), Colors.Red);
            });
    }
}
