using Godot;
using Godot.Collections;

[Tool]
public partial class Element : Control
{
    public Array<float> X = new();
    public Array<float> Y = new();
    public Array<float> NormalizedX = new();
    public Array<float> NormalizedY = new();
}

// minX -= (maxX - minX) * 0.02f;
// maxX += (maxX - minX) * 0.02f;
// minY -= (maxY - minY) * 0.05f;
// maxY += (maxY - minY) * 0.05f;

// GD.Print("minX: " + minX);
// GD.Print("maxX: " + maxX);
// GD.Print("minY: " + minY);
// GD.Print("maxY: " + maxY);
// GD.Print();
