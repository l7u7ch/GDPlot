using System;
using Godot;

public partial class YAxis : Control
{
    public float MaxValue = 0;
    public float MinValue = 0;
    public int Digits = 3;
    public int Ticks = 3;

    public override void _Draw()
    {
        float Unit = (MaxValue - MinValue) / Ticks;

        for (int i = 0; i <= Ticks; i++)
        {
            Font _Font = ThemeDB.FallbackFont;
            float _X = 0;
            float _Y = Size.Y - i * (Size.Y / Ticks);
            DrawString( //
                font: _Font,
                pos: new(_X, _Y),
                text: Math.Round(i * Unit + MinValue, Digits).ToString(),
                alignment: HorizontalAlignment.Right,
                width: 64
            );
        }
    }
}
