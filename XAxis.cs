using System;
using Godot;

[Tool]
public partial class XAxis : Control
{
    public int Ticks = 6;
    public float MinValue = 0;
    public float MaxValue = 0;

    public override void _Draw()
    {
        float Unit = (MaxValue - MinValue) / Ticks;

        for (int i = 0; i <= Ticks; i++)
        {
            Font Font = ThemeDB.FallbackFont;
            float X = i * (Size.X / Ticks);
            float Y = Size.Y;
            DrawString(Font, new Vector2(X, Y), Math.Round(i * Unit + MinValue, 1).ToString());
        }
    }
}

// using Godot.Collections;
// using System.Linq;

// DrawLine(new Vector2(0, 0), new Vector2(0, GetRect().Size.Y), Colors.Green);
// DrawLine(new Vector2(0, 0), new Vector2(GetRect().Size.X, 0), Colors.Green);
// DrawLine(new Vector2(0, GetRect().Size.Y), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Green);
// DrawLine(new Vector2(GetRect().Size.X, 0), new Vector2(GetRect().Size.X, GetRect().Size.Y), Colors.Green);

// DrawString(ThemeDB.FallbackFont, new Vector2(x, y), (i * (100 / N)).ToString());

// float[] allX = Elements.Where(e => e.X != null).SelectMany(e => e.X).DefaultIfEmpty().ToArray();
// float maxX = allX.Max();
// GD.Print("maxX: " + maxX);

// private Array<Element> Elements = new();

// public override void _Ready() { }

// public void AddElement(Element e)
// {
//     Elements.Add(e);
// }

// DrawRect(new Rect2(Vector2.Zero, GetRect().Size), Colors.Green);


// private void DrawLabels()
// {

//

//     for (int i = 0; i <= X; i++)
//     {
//         // X軸
//         float x = i * (GetRect().Size.X / X);
//         float y = GetRect().Size.Y + 50;
//         DrawString(font, new Vector2(x, y), (i * (GetMaxValue().X / X)).ToString());

//         // Y軸
//         x = 0;
//         y = graphPosition.Y + GetRect().Size.Y - i * (GetRect().Size.Y / X);
//         DrawString(font, new Vector2(x, y), (i * (GetMaxValue().Y / X)).ToString());
//     }
// }
