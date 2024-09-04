using System.Linq;
using Godot;
using Godot.Collections;

public partial class Plot : Control
{
    private Array<Element> Elements = new();
    public Color GridColor = Colors.LightSlateGray;
    public int GridTicksX = 6;
    public int GridTicksY = 6;
    public bool IsGrid = true;

    private void DrawGrid()
    {
        // 縦線を描画する
        for (float x = 0; x <= Size.X; x += Size.X / GridTicksX)
        {
            DrawLine(new Vector2(x, 0), new Vector2(x, Size.Y), GridColor);
        }

        // 横線を描画する
        for (float y = 0; y <= Size.Y; y += Size.Y / GridTicksY)
        {
            DrawLine(new Vector2(0, y), new Vector2(Size.X, y), GridColor);
        }
    }

    public override void _Draw()
    {
        if (IsGrid)
        {
            DrawGrid();
        }

        // Elementのプロパティを更新する
        Elements
            .ToList()
            .ForEach(e =>
            {
                e.MaxValue = GetMaxValue();
                e.MinValue = GetMinValue();
                e.Position = Vector2.Zero;
                e.Size = Size;
                e.QueueRedraw();
            });
    }

    public Bar CreateBar()
    {
        Bar Bar = new();

        Elements.Add(Bar);
        AddChild(Bar);

        return Bar;
    }

    public Line CreateLine()
    {
        Line Line = new();

        Elements.Add(Line);
        AddChild(Line);

        return Line;
    }

    public Vector2 GetMaxValue()
    {
        float MaxValueX = Elements.SelectMany(e => e.Points).DefaultIfEmpty().Max(Point => Point.X);
        float MaxValueY = Elements.SelectMany(e => e.Points).DefaultIfEmpty().Max(Point => Point.Y);

        return new(MaxValueX, MaxValueY);
    }

    public Vector2 GetMinValue()
    {
        float MinValueX = Elements.SelectMany(e => e.Points).DefaultIfEmpty().Min(Point => Point.X);
        float MinValueY = Elements.SelectMany(e => e.Points).DefaultIfEmpty().Min(Point => Point.Y);

        return new(MinValueX, MinValueY);
    }
}
