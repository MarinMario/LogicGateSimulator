using Godot;

public class Gate : Node2D
{
    public enum GateType { And, Or, Xor }
    [Export]
    public GateType gateType = GateType.And;
    public override void _Process(float delta)
    {
        var inputPin1 = GetNode<InputPin>("InputPin1");
        var inputPin2 = GetNode<InputPin>("InputPin2");
        var outputPin = GetNode<OutputPin>("OutputPin");

        switch (gateType)
        {
            case GateType.And:
                outputPin.Value = inputPin1.Value && inputPin2.Value;
                break;
            case GateType.Or:
                outputPin.Value = inputPin1.Value || inputPin2.Value;
                break;
            case GateType.Xor:
                outputPin.Value = inputPin1.Value ^ inputPin2.Value;
                break;
        }

        GetNode<Button>("Button").Text = gateType.ToString();
    }
}
