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

        // 全ての配列を平坦化する
        // ここの部分が GetMaxValue とか GetMinValue とかで分離すべき
        float[] allX = Elements.Where(e => e.X != null).SelectMany(e => e.X).DefaultIfEmpty().ToArray();
        float[] allY = Elements.Where(e => e.Y != null).SelectMany(e => e.Y).DefaultIfEmpty().ToArray();

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

    public Scatter CreateScatter()
    {
        Scatter Scatter = new();

        Elements.Add(Scatter);
        AddChild(Scatter);

        return Scatter;
    }

    public Vector2 GetMaxValue()
    {
        float[] allX = Elements.Where(e => e.X != null).SelectMany(e => e.X).DefaultIfEmpty().ToArray();
        float[] allY = Elements.Where(e => e.Y != null).SelectMany(e => e.Y).DefaultIfEmpty().ToArray();
        return new Vector2(allX.Max(), allY.Max());
    }

    public Vector2 GetMinValue()
    {
        float[] allX = Elements.Where(e => e.X != null).SelectMany(e => e.X).DefaultIfEmpty().ToArray();
        float[] allY = Elements.Where(e => e.Y != null).SelectMany(e => e.Y).DefaultIfEmpty().ToArray();
        return new Vector2(allX.Min(), allY.Min());
    }
}
