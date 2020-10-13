using Godot;
using System;
using System.Diagnostics;

public class OutputPin : Node2D, IPin
{
    public bool Value { get; set; }
    public IPin ConnectedPin { get; set; }


    public void OnPressed()
    {
        var manager = GetNode<Manager>("/root/Manager");
        if (ConnectedPin == null && manager.lastOutputPin == null)
        {
            manager.lastOutputPin = this;
            if (manager.lastInputPin == null)
                manager.AddWire(this);
        }
        
    }

}
