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
