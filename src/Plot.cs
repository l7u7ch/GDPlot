using Godot;

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
