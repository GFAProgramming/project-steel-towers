using Godot;
using SteelTowers.Types;


namespace SteelTowers.Attribute_Component
{
    [GlobalClass]
    public partial class AttributeComponent : Node
    {
        [Signal] public delegate void OnValueChangeEventHandler(double currentValue, double oldValue, double delta);
        [Signal] public delegate void OnValueMaxEventHandler(double currentValue, double oldValue, double delta);
        [Signal] public delegate void OnValueMinEventHandler(double currentValue, double oldValue, double delta);
        [Signal] public delegate void OnMaxChangeEventHandler(double currentMax, double oldMax, double delta);
        [Signal] public delegate void OnMinChangeEventHandler(double currentMin, double oldMin, double delta);

        [Export]
        public double Max
        {
            get => GetMax();
            set => SetMax(value);
        }

        [Export]
        public double Min
        {
            get => GetMin();
            set => SetMin(value);
        }

        [Export]
        public double Value
        {
            get => GetValue();
            set => SetValue(value);
        }
        
        private RangedNumeric<double> _value = new();

        public AttributeComponent()
        {
            _value.OnValueChange += _On_Internal_Value_Change;
            _value.OnMaxChange += _On_Max_Change;
            _value.OnMinChange += _On_Min_Change;
        }

        public override void _ExitTree()
        {
            _value.OnValueChange -= _On_Internal_Value_Change;
        }
        
        public void SetValue(double value)
        {
            _value.Value = value;
        }

        public double GetValue()
        {
            return _value.Value;
        }

        public void SetMax(double value)
        {
            _value.Max = value;
        }

        public double GetMax()
        {
            return _value.Max;
        }

        public void SetMin(double value)
        {
            _value.Min = value;
        }
        
        public double GetMin()
        {
            return _value.Min;
        }
        
        // ik gross, but i never actually use the sender param so idc.
        // I just needed to convert the internal C# style EventHandler to a Godot Signal
        #nullable enable
        public void _On_Internal_Value_Change(object? sender, RangedNumeric<double>.OnValueChangeArgs args )
        {
            EmitSignalOnValueChange(args.NewValue, args.OldValue, args.Delta);
            
            // Check if the value of Value has become the Min value.
            if (double.Abs(args.NewValue - _value.Min) <= double.Epsilon)
            //if (args.NewValue == _value.Min)
            {
                EmitSignalOnValueMin(args.NewValue, args.OldValue, args.Delta);
            } 
            // Check if the value of Value has become the Max value.
            else if (double.Abs(args.NewValue - _value.Max) <= double.Epsilon)
            {
                EmitSignalOnValueMax(args.NewValue, args.OldValue, args.Delta);
            }
        }

        public void _On_Max_Change(object? sender, RangedNumeric<double>.OnValueChangeArgs args)
        {
            EmitSignalOnMaxChange(args.NewValue, args.OldValue, args.Delta);
        }

        public void _On_Min_Change(object? sender, RangedNumeric<double>.OnValueChangeArgs args)
        {
            EmitSignalOnMinChange(args.NewValue, args.OldValue, args.Delta);
        }
    }
}

