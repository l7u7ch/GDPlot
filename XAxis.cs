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
