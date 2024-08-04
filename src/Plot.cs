using Godot;

public partial class Plot : Control
{
    public override void _Draw()
    {
        int N = 6;

        // 縦線
        for (float x = Size.X / N; x < Size.X; x += Size.X / N)
        {
            DrawLine(new Vector2(x, 0), new Vector2(x, Size.Y), Colors.LightSlateGray);
        }

        // 横線
        for (float y = Size.Y / N; y < Size.Y; y += Size.Y / N)
        {
            DrawLine(new Vector2(0, y), new Vector2(Size.X, y), Colors.LightSlateGray);
        }
    }
}
