using System;
using Godot;

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
            Font _Font = ThemeDB.FallbackFont;
            float _X = Size.X / Ticks * i;
            float _Y = _Font.GetAscent() - _Font.GetDescent();
            DrawString( //
                font: _Font,
                pos: new(_X, _Y),
                text: Math.Round(i * Unit + MinValue, 1).ToString()
            );
        }
    }
}
