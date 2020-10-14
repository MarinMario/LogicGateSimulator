using Godot;
using System;

public class Manager : Node2D
{
    public static Manager Node;
    public InputPin LastInputPinPressed;
    public OutputPin LastOutputPinPressed;

    public override void _Ready()
    {
        Node = this;
    }

    public override void _Process(float delta)
    {
        if (LastInputPinPressed != null && LastOutputPinPressed != null)
        {
            LastInputPinPressed.ConnectedPin = LastOutputPinPressed;
            LastInputPinPressed = null;
            LastOutputPinPressed = null;
        }
    }
}
