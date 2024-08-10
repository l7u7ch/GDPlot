using System.Linq;
using Godot;

public partial class Line : Element
{
    public Color LineColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int LineWeight = 2;

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
    }
}
