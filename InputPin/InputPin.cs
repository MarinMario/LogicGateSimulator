using Godot;
using System;

public class InputPin : Node2D
{
    public bool Value = false;
    public OutputPin ConnectedPin;

    public override void _Process(float delta)
    {
        Value = ConnectedPin != null && ConnectedPin.Value;

        Update();
    }

    void OnPressed()
    {
        Manager.Node.LastInputPinPressed = this;
    }

    public override void _Draw()
    {
        var lineColor = Value ? Color.ColorN("blue") : Color.ColorN("gray");
        if (ConnectedPin != null)
            DrawLine(Vector2.Zero, ConnectedPin.GlobalPosition - GlobalPosition, lineColor, 10);
    }
}
