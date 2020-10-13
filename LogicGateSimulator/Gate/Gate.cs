using Godot;
using Godot.Collections;

public class Gate : Draggable
{
    enum Type { Or, And, Not }

    [Export]
    Type type = Type.And;
    OutputPin outputPin;

    protected override void Ready()
    {
        outputPin = GetNode<OutputPin>("OutputPin");
        GetNode<Label>("Label").Text = type.ToString();
    }

    protected override void Process(float delta)
    {
        var inputPins = GetNode("InputPins").GetChildren();
        var output = false;
        
        switch (type)
        {
            case Type.Or:
                foreach (IPin pin in inputPins)
                    output = output || pin.Value;
                break;
            case Type.And:
                output = true;
                foreach (IPin pin in inputPins)
                    output = output && pin.Value;
                break;
            case Type.Not:
                output = !(inputPins[0] as IPin).Value;
                break;
        }

        outputPin.Value = output;

        if (mouseOver && Input.IsActionJustPressed("right_click"))
        {
            foreach (IPin pin in inputPins)
                pin.Despawn();
            outputPin.Despawn();
            QueueFree();
        }
    }

    void AddInputPin()
    {
        var pin = (InputPin)ResourceLoader.Load<PackedScene>("res://InputPin/InputPin.tscn").Instance();
        GetNode<Node2D>("InputPins").AddChild(pin);
    }
}
