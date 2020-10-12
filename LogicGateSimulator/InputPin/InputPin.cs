using Godot;
using System;

public class InputPin : Pin
{
    public OutputPin connectedPin;

    protected override void Process(float delta)
    {
        value = connectedPin != null ? connectedPin.value : false;
        var manager = GetNode<Manager>("/root/Manager");

        if (Input.IsActionJustPressed("click") && mouseOver)
            if (manager.lastInputPin == this)
                manager.lastInputPin = null;
            else
                manager.lastInputPin = this;

        if (manager.lastInputPin == this && manager.lastOutputPin != null)
        {
            connectedPin = manager.lastOutputPin;
            manager.lastInputPin = null;
            manager.lastOutputPin = null;
        }

        RunOnce();
    }

    bool ran = false;
    void RunOnce()
    {
        if (!ran)
        {
            var wire = (Wire)ResourceLoader.Load<PackedScene>("res://Wire/Wire.tscn").Instance();
            wire.Init(this);
            GetParent().GetParent().AddChild(wire);

            ran = true;
        }
    }
}
