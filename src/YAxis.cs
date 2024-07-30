using System;
using Godot;

public partial class YAxis : Control
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
            float X = 0;
            float Y = Position.Y + Size.Y - i * (Size.Y / Ticks);
            DrawString(Font, new Vector2(X, Y), Math.Round(i * Unit + MinValue, 1).ToString());
        }
    }
}
