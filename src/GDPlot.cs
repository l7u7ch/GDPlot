using Godot;

[Tool]
public partial class GDPlot : Control
{
    public Plot Plot = new();
    public XAxis XAxis = new();
    public YAxis YAxis = new();

    [Export]
    public string Title = "";

    public override void _Ready()
    {
        AddChild(Plot);
        AddChild(XAxis);
        AddChild(YAxis);
    }

    public override void _Draw()
    {
        // タイトルを描画する
        DrawString( //
            font: ThemeDB.FallbackFont,
            pos: new(0, 0),
            text: Title,
            alignment: HorizontalAlignment.Center,
            width: Size.X
        );

        // Plot, XAxis, YAxis の Size と Position を更新する
        Plot.Size = Size;
        Plot.Position = Vector2.Zero;
        XAxis.Size = new Vector2(Size.X, 0);
        XAxis.Position = new Vector2(0, Size.Y);
        YAxis.Size = new Vector2(0, Size.Y);
        YAxis.Position = new Vector2(-64, 0);

        // 最大値と最小値を取得する
        Vector2 MaxValue = Plot.GetMaxValue();
        Vector2 MinValue = Plot.GetMinValue();

        // XAxis と YAxis の最大値と最小値を更新する
        XAxis.MaxValue = MaxValue.X;
        XAxis.MinValue = MinValue.X;
        YAxis.MaxValue = MaxValue.Y;
        YAxis.MinValue = MinValue.Y;

        // Plot, XAxis, YAxis を再描画する
        Plot.QueueRedraw();
        XAxis.QueueRedraw();
        YAxis.QueueRedraw();
    }
}
