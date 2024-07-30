using System.Linq;
using Godot;
using Godot.Collections;

public partial class GPlot : Control
{
    private Array<Element> Elements = new();
    private Plot Plot = new();
    private XAxis XAxis = new();
    private YAxis YAxis = new();

    public override void _Ready()
    {
        int Left = 40;
        int Right = 20;

        // Plot
        Plot.Position = new Vector2(Left, 0);
        Plot.Size = Size - new Vector2(Left, Right);
        AddChild(Plot);

        // XAxis
        XAxis.Position = Size - new Vector2(Size.X - Left, Right);
        XAxis.Size = new Vector2(Size.X - Left, Right);
        AddChild(XAxis);

        // YAxis
        YAxis.Position = Vector2.Zero;
        YAxis.Size = Size - new Vector2(Size.X - Left, Right);
        AddChild(YAxis);
    }

    public override void _Draw()
    {
        int Top = 45;
        int Bottom = 15;
        int Left = 15;
        int Right = 45;

        Vector2 TopLeft = new Vector2(0 - Left, 0 - Top);
        Vector2 TopRight = new Vector2(Size.X + Right, 0 - Top);
        Vector2 BottomLeft = new Vector2(0 - Left, Size.Y + Bottom);
        Vector2 BottomRight = new Vector2(Size.X + Right, Size.Y + Bottom);

        DrawLine(TopLeft, TopRight, Colors.LightSlateGray); // 上横線
        DrawLine(BottomLeft, BottomRight, Colors.LightSlateGray); // 下横線
        DrawLine(TopLeft, BottomLeft, Colors.LightSlateGray); // 左縦線
        DrawLine(TopRight, BottomRight, Colors.LightSlateGray); // 右縦線
    }

    public Bar CreateBar()
    {
        Bar Bar = new();

        Bar.Position = Vector2.Zero;
        Bar.Size = Plot.Size;

        Elements.Add(Bar);
        Plot.AddChild(Bar);

        return Bar;
    }

    public Line CreateLine()
    {
        Line Line = new();

        Plot.AddChild(Line);

        Elements.Add(Line);

        return Line;
    }

    public Scatter CreateScatter()
    {
        Scatter Scatter = new();

        Plot.AddChild(Scatter);

        Elements.Add(Scatter);

        return Scatter;
    }

    public void Redraw()
    {
        // 正規化
        Normalize();

        // 再描画
        Elements.ToList().ForEach(e => e.QueueRedraw());
        Plot.QueueRedraw();
        XAxis.QueueRedraw();
        YAxis.QueueRedraw();
    }

    private void Normalize()
    {
        // 全ての配列を平坦化する
        float[] allX = Elements.Where(e => e.X != null).SelectMany(e => e.X).DefaultIfEmpty().ToArray();
        float[] allY = Elements.Where(e => e.Y != null).SelectMany(e => e.Y).DefaultIfEmpty().ToArray();

        // 最大値と最小値を取得する
        float minX = allX.Min();
        float maxX = allX.Max();
        float minY = allY.Min();
        float maxY = allY.Max();

        // 軸に値を設定する
        XAxis.MinValue = minX;
        XAxis.MaxValue = maxX;
        YAxis.MinValue = minY;
        YAxis.MaxValue = maxY;

        // 正規化する
        foreach (Element e in Elements)
        {
            e.NormalizedX = new Array<float>(e.X.Select(x => (x - minX) / (maxX - minX) * Plot.Size.X));
            e.NormalizedY = new Array<float>(e.Y.Select(y => Plot.Size.Y - (y - minY) / (maxY - minY) * Plot.Size.Y));
        }
    }
}
