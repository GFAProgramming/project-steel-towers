using Godot;
using System;
using System.Globalization;
using System.Threading;
using SteelTowers.Attribute_Component;

public partial class TmpAttrTest : Node2D
{
    [Export] private AttributeComponent _attr;
    
    private Label _valueLabel;
    private Button _valueAddButton;
    private Button _valueSubtractButton;

    private Label _minLabel;
    private Button _minAddButton;
    private Button _minSubtractButton;
    
    private Label _maxLabel;
    private Button _maxAddButton;
    private Button _maxSubtractButton;

    private TextEdit _eventLog;
    
    public override void _Ready()
    {
        _valueLabel = GetNode<Label>("%ValueLabel");
        _valueAddButton = GetNode<Button>("%AddValue");
        _valueSubtractButton = GetNode<Button>("%SubtractValue");
        
        _minLabel = GetNode<Label>("%MinLabel");
        _minAddButton = GetNode<Button>("%AddMin");
        _minSubtractButton = GetNode<Button>("%SubtractMin");
        
        _maxLabel = GetNode<Label>("%MaxLabel");
        _maxAddButton = GetNode<Button>("%AddMax");
        _maxSubtractButton = GetNode<Button>("%SubtractMax");
     
        _eventLog = GetNode<TextEdit>("%EventLog");
        
        _attr = GetNode<AttributeComponent>("%AttributeComponent");

        _valueAddButton.ButtonDown += AddValue;
        _valueSubtractButton.ButtonDown += SubtractValue;
        _minAddButton.ButtonDown += AddMin;
        _minSubtractButton.ButtonDown += SubtractMin;
        _maxAddButton.ButtonDown += AddMax;
        _maxSubtractButton.ButtonDown += SubtractMax;

        _attr.OnValueChange += UpdateValueLabel;
        _attr.OnMaxChange += UpdateMaxLabel;
        _attr.OnMinChange += UpdateMinLabel;
        
        _attr.OnValueMin += ValueBecomesMin;
        _attr.OnValueMax += ValueBecomesMax;
        
        UpdateValueLabel();
        UpdateMaxLabel();
        UpdateMinLabel();
    }

    public void UpdateValueLabel(double newValue = 0, double oldValue = 0, double delta = 0)
    {
        _valueLabel.Text = $"{_attr.GetValue()} ({newValue}-{oldValue}: {delta})";

        _eventLog.Text = $"Updated Value\n{_eventLog.Text}";
    }

    public void UpdateMaxLabel(double newValue = 0, double oldValue = 0, double delta = 0)
    {
        _maxLabel.Text = $"{_attr.GetMax()} ({newValue}-{oldValue}: {delta})";
        
        _eventLog.Text = $"Updated Min\n{_eventLog.Text}";
    }

    public void UpdateMinLabel(double newValue = 0, double oldValue = 0, double delta = 0)
    {
        _minLabel.Text = $"{_attr.GetMin()} ({newValue}-{oldValue}: {delta})";
        
        _eventLog.Text = $"Updated Min\n{_eventLog.Text}";
    }

    public void ValueBecomesMax(double newValue = 0, double oldValue = 0, double delta = 0)
    {
        _eventLog.Text = $"Value ({_attr.Value}) has become Max ({_attr.Max})\n{_eventLog.Text}";
    }
    
    public void ValueBecomesMin(double newValue = 0, double oldValue = 0, double delta = 0)
    {
        _eventLog.Text = $"Value ({_attr.Value}) has become Min ({_attr.Min})\n{_eventLog.Text}";
    }
    
    public void AddValue()
    {
        _attr.Value += 1;
    }

    public void SubtractValue()
    {
        _attr.Value -= 1;
    }

    public void AddMin()
    {
        _attr.Min += 1;
    }

    public void SubtractMin()
    {
        _attr.Min -= 1;
    }

    public void AddMax()
    {
        _attr.Max += 1;
    }

    public void SubtractMax()
    {
        _attr.Max -= 1;
    }
}
