using Godot;
using System;

public class Gate : Draggable
{
    enum Type { Or, And, Not }

    [Export]
    Type type = Type.And;
    InputPin inputPin1;
    InputPin inputPin2;
    OutputPin outputPin;

    protected override void Ready()
    {
        inputPin1 = GetNode<InputPin>("InputPin1");
        inputPin2 = GetNode<InputPin>("InputPin2");
        outputPin = GetNode<OutputPin>("OutputPin");
        GetNode<Label>("Label").Text = type.ToString();
    }

    protected override void Process(float delta)
    {
        var ip1 = inputPin1.Value;
        var ip2 = inputPin2.Value;
        switch (type)
        {
            case Type.Or:
                outputPin.Value = ip1 || ip2;
                break;
            case Type.And:
                outputPin.Value = ip1 && ip2;
                break;
            case Type.Not:
                outputPin.Value = !ip1;
                break;
        }
    }
}
