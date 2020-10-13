using Godot;
using System;

public class Switch : Draggable
{
    OutputPin outputPin;

    protected override void Ready()
    {
        outputPin = GetNode<OutputPin>("OutputPin");
    }

    protected override void Process(float delta)
    {
        if (Input.IsActionJustPressed("click") && mouseOver)
        {
            outputPin.Value = !outputPin.Value;
            GetNode<ColorRect>("ColorRect").Color = outputPin.Value ? Color.ColorN("green") : Color.ColorN("red");
        }
    }
}
