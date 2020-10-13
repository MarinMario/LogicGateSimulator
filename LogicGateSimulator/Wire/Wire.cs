using Godot;
using System;

public class Wire : Node2D
{
    IPin pin;
    Line2D line;

    public override void _Ready()
    {
        line = GetNode<Line2D>("Line2D");
        line.GlobalPosition = new Vector2(0, 0);
    }

    public void Init(IPin pin)
    {
        this.pin = pin;
    }

    public override void _Process(float delta)
    {

        var delete = GetNode<Node2D>("Delete");
        line.DefaultColor = pin.Value ? Color.ColorN("green") : Color.ColorN("red");
        if (pin.ConnectedPin != null)
        {
            line.Points = new Vector2[] { (pin as Node2D).GlobalPosition, (pin.ConnectedPin as Node2D).GlobalPosition };

            delete.GlobalPosition = line.Points[0] / 2 + line.Points[1] / 2;
            delete.Visible = true;
        }
        else
        {
            line.Points = new Vector2[] { (pin as Node2D).GlobalPosition, GetGlobalMousePosition() };
            delete.Visible = false;
        }

        if (Input.IsActionJustPressed("right_click") && pin.ConnectedPin == null)
        {
            var manager = GetNode<Manager>("/root/Manager");
            manager.lastInputPin = null;
            manager.lastOutputPin = null;
            QueueFree();
        }

    }

    void OnDeletePressed()
    {
        pin.ConnectedPin.ConnectedPin = null;
        pin.ConnectedPin = null;
        QueueFree();
    }
}
