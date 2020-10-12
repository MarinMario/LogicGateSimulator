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
            outputPin.value = !outputPin.value;
            GetNode<ColorRect>("ColorRect").Color = outputPin.value ? Color.ColorN("green") : Color.ColorN("red");
        }
    }
}
