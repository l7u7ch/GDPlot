using Godot;

[Tool]
public partial class Plot : Control
{
    public override void _Draw()
    {
        // 縦線
        for (float x = 0; x <= Size.X; x += Size.X / 10)
        {
            DrawLine(new Vector2(x, 0), new Vector2(x, Size.Y), Colors.LightSlateGray);
        }

        // 横線
        for (float y = 0; y <= Size.Y; y += Size.Y / 10)
        {
            DrawLine(new Vector2(0, y), new Vector2(Size.X, y), Colors.LightSlateGray);
        }
    }
}

// using Godot.Collections;
// using System.Linq;

// public override void _Draw() { }

// private void DrawFrame() { }

// DrawFrame();

// DrawLine(new Vector2(0, 0), new Vector2(0, GetRect().Size.Y), Colors.Red);
// DrawLine(new Vector2(0, 0), new Vector2(GetRect().Size.X, 0), Colors.Red);
// DrawLine(new Vector2(0, GetRect().Size.Y), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Red);
// DrawLine(new Vector2(GetRect().Size.X, 0), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Red);

// public void SetElement(Element Element)
// {
//     Elements.Add(Element);
//     AddChild(Element);
// }
