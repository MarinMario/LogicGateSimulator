using Godot;
using System;

public class OutputPin : Node2D
{
    public bool Value = false;

    void OnPressed()
    {
        Manager.Node.LastOutputPinPressed = this;
    }
}
