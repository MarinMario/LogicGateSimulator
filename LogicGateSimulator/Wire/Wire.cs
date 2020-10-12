using Godot;
using System;

public class Wire : Node2D
{
    InputPin inputPin;
    Line2D line;

    public override void _Ready()
    {
        line = GetNode<Line2D>("Line2D");
        line.GlobalPosition = new Vector2(0, 0);
    }

    public void Init(InputPin inputPin)
    {
        this.inputPin = inputPin;
    }
    public override void _Process(float delta)
    {
        if (inputPin.connectedPin != null)
        {
            //GlobalPosition = inputPin.GlobalPosition;
            line.Points = new Vector2[] { inputPin.GlobalPosition, inputPin.connectedPin.GlobalPosition };
            line.DefaultColor = inputPin.value ? Color.ColorN("green") : Color.ColorN("red");
        }
    }
}
