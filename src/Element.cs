using System.Linq;
using Godot;
using Godot.Collections;

public static class ArrayExtensions
{
    public static void AddLimit(this Array<Vector2> Points, Vector2 Item)
    {
        Points.AddLimit(Item, 10);
    }

    public static void AddLimit(this Array<Vector2> Points, Vector2 Item, int Limit)
    {
        Points.Add(Item);

        if (Limit < Points.Count)
        {
            for (int i = 0; i < (Points.Count - Limit); i++)
            {
                Points.RemoveAt(0);
            }
        }
    }
}

public partial class Element : Control
{
    public Array<Vector2> Points = new();
    public Vector2 MaxValue = Vector2.Zero;
    public Vector2 MinValue = Vector2.Zero;

    public Array<Vector2> Normalize()
    {
        return new Array<Vector2>(
            Points.Select(Point => new Vector2(
                x: (Point.X - MinValue.X) / (MaxValue.X - MinValue.X) * Size.X,
                y: (1 - ((Point.Y - MinValue.Y) / (MaxValue.Y - MinValue.Y))) * Size.Y
            ))
        );
    }
}
