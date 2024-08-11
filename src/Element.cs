using System.Linq;
using Godot;
using Godot.Collections;

public partial class Element : Control
{
    public Array<float> X = new();
    public Array<float> Y = new();
    public Vector2 MaxValue = Vector2.Zero;
    public Vector2 MinValue = Vector2.Zero;

    public Array<Vector2> Normalize()
    {
        Array<float> NormalizedX = new Array<float>(X.Select(x => (x - MinValue.X) / (MaxValue.X - MinValue.X) * Size.X));
        Array<float> NormalizedY = new Array<float>(Y.Select(y => (1 - (y - MinValue.Y) / (MaxValue.Y - MinValue.Y)) * Size.Y));
        return new Array<Vector2>(NormalizedX.Zip(NormalizedY, (x, y) => new Vector2(x, y)));
    }
}
