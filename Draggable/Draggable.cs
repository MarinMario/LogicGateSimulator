using Godot;
using System;

public class Draggable : Node2D
{
    bool MouseOver = false;
    bool FollowMouse = false;

    public override void _Process(float delta)
    {
        var mouse = GetGlobalMousePosition();
        MouseOver = GlobalPosition.DistanceTo(mouse) < 50;

        if (Input.IsActionJustPressed("click") && MouseOver)
            FollowMouse = true;
        if (Input.IsActionJustReleased("click"))
            FollowMouse = false;

        if (FollowMouse)
            GetParent<Node2D>().GlobalPosition = mouse;

    }
}
