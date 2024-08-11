using System.Linq;
using Godot;

public partial class Line : Element
{
    public Color LineColor = new(GD.Randf(), GD.Randf(), GD.Randf());
    public int LineWeight = 2;

    public override void _Draw()
    {
        if (X.Count < 2 || Y.Count < 2)
        {
            return;
        }

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
