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
            Vector2 _Position = new Vector2(_X, _Y);
            string _Text = Math.Round(i * Unit + MinValue, 1).ToString();
            DrawString(font: _Font, pos: _Position, text: _Text);
        }
    }
}
