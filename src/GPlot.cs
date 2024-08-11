using Godot;

public partial class GPlot : Control
{
    public Plot Plot = new();
    private XAxis XAxis = new();
    private YAxis YAxis = new();
    public Color FrameColor = Colors.LightSlateGray;
    public bool IsFrame = true;

    private void DrawFrame() { }

    public override void _Ready()
    {
        AddChild(Plot);
        AddChild(XAxis);
        AddChild(YAxis);
    }

    public override void _Draw()
    {
        if (IsFrame)
        {
            DrawFrame();
        }

        int YOKO = 30;
        int TATE = 20;

        // Plot, XAxis, YAxis の Size と Position を更新する
        Plot.Size = Size - new Vector2(YOKO, TATE);
        Plot.Position = new Vector2(YOKO, 0);
        XAxis.Size = new Vector2(Size.X - YOKO - 35, TATE);
        XAxis.Position = new Vector2(YOKO, Size.Y - XAxis.Size.Y);
        YAxis.Size = new Vector2(YOKO, Size.Y - TATE - 20);
        YAxis.Position = new Vector2(0, 20);

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
