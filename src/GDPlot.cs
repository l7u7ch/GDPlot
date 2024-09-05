using System;
using System.Linq;
using Godot;
using Godot.Collections;

[Tool]
public partial class GDPlot : Control
{
    private float MaxValueX;
    private float MaxValueY;
    private float MinValueX;
    private float MinValueY;
    private Array<Vector2> Normalized;

    [Export]
    public Array<Vector2> Points = new();

    [Export]
    public Color BarColor = Colors.Red;

    [Export]
    public Color GridColor = Colors.LightSlateGray;

    [Export]
    public Color LineColor = Colors.Red;

    [Export]
    public Color MarkerColor = Colors.Red;

    [Export]
    public Font AxisFontX = ThemeDB.FallbackFont;

    [Export]
    public Font AxisFontY = ThemeDB.FallbackFont;

    [Export]
    public Font TitleFont = ThemeDB.FallbackFont;

    [Export]
    public int AxisFontSizeX = 12;

    [Export]
    public int AxisFontSizeY = 12;

    [Export]
    public int AxisTicksX = 3;

    [Export]
    public int AxisTicksY = 3;

    [Export]
    public int BarWeight = 0;

    [Export]
    public int GridTicksX = 4;

    [Export]
    public int GridTicksY = 4;

    [Export]
    public int LineWeight = 2;

    [Export]
    public int MarkerSize = 4;

    [Export]
    public int TitleFontSize = 16;

    [Export]
    public string Title = "UNTITLED";

    public override void _Draw()
    {
        MaxValueX = Points.DefaultIfEmpty().Max(Point => Point.X);
        MaxValueY = Points.DefaultIfEmpty().Max(Point => Point.Y);
        MinValueX = Points.DefaultIfEmpty().Min(Point => Point.X);
        MinValueY = Points.DefaultIfEmpty().Min(Point => Point.Y);

        Normalized = new Array<Vector2>(
            Points.Select(Point => new Vector2(
                x: (Point.X - MinValueX) / (MaxValueX - MinValueX) * Size.X,
                y: (1 - ((Point.Y - MinValueY) / (MaxValueY - MinValueY))) * Size.Y
            ))
        );

        DrawGrid();
        DrawBar();
        DrawLine();
        DrawScatter();
        DrawTicksX();
        DrawTicksY();
        DrawTitle();
    }

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

    private void DrawBar()
    {
        Normalized
            .ToList()
            .ForEach(Point =>
            {
                DrawRect(new Rect2(Point.X - (BarWeight / 2), Size.Y, BarWeight, Point.Y - Size.Y), Colors.Red);
            });
    }

    private void DrawLine()
    {
        if (Points.Count < 2)
        {
            return;
        }

        Normalized.Aggregate(
            (prev, curr) =>
            {
                DrawLine(prev, curr, LineColor, LineWeight);
                return curr;
            }
        );
    }

    private void DrawScatter()
    {
        Normalized
            .ToList()
            .ForEach(Point =>
                DrawCircle( //
                    position: Point,
                    radius: MarkerSize,
                    color: MarkerColor
                )
            );
    }

    private void DrawTicksX()
    {
        for (int i = 0; i <= AxisTicksX; i++)
        {
            float x = Size.X / AxisTicksX * i;
            float y = Size.Y + AxisFontX.GetAscent() - AxisFontX.GetDescent();
            DrawString( //
                font: AxisFontX,
                pos: new(x, y),
                text: Math.Round(MinValueX + (MaxValueX - MinValueX) / AxisTicksX * i, 3).ToString(),
                fontSize: AxisFontSizeX
            );
        }
    }

    private void DrawTicksY()
    {
        for (int i = 0; i <= AxisTicksY; i++)
        {
            float x = -64;
            float y = Size.Y - i * (Size.Y / AxisTicksY);
            DrawString( //
                font: AxisFontY,
                pos: new(x, y),
                text: Math.Round(MinValueY + (MaxValueY - MinValueY) / AxisTicksY * i, 3).ToString(),
                alignment: HorizontalAlignment.Right,
                width: 64,
                fontSize: AxisFontSizeY
            );
        }
    }

    private void DrawTitle()
    {
        DrawString( //
            font: ThemeDB.FallbackFont,
            pos: new(0, 0),
            text: Title,
            alignment: HorizontalAlignment.Center,
            width: Size.X,
            fontSize: TitleFontSize
        );
    }
}

public static class ArrayExtensions
{
    public static void AddLimit(this Array<Vector2> Points, Vector2 Item)
    {
        Points.AddLimit(Item, 10);
    }

    public static void AddLimit(this Array<Vector2> Points, Vector2 Item, int Limit)
    {
        Points.Add(Item);

        if (Limit < Points.Count)
        {
            for (int i = 0; i < (Points.Count - Limit); i++)
            {
                Points.RemoveAt(0);
            }
        }
    }
}
