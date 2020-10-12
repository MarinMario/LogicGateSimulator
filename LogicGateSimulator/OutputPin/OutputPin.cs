using Godot;
using System;
using System.Diagnostics;

public class OutputPin : Pin
{
    protected override void Process(float delta)
    {
        var manager = GetNode<Manager>("/root/Manager");
        if (Input.IsActionJustPressed("click") && mouseOver)
            if (manager.lastOutputPin == this)
                manager.lastOutputPin = null;
            else
                manager.lastOutputPin = this;
    }
}
