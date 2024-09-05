using System;
using Godot;

public partial class XAxis : Control
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
            float _X = Size.X / Ticks * i;
            float _Y = _Font.GetAscent() - _Font.GetDescent();
            DrawString( //
                font: _Font,
                pos: new(_X, _Y),
                text: Math.Round(i * Unit + MinValue, Digits).ToString()
            );
        }
    }
}
