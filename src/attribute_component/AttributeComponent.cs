using Godot;
using System;
using SteelTowers.Types;


namespace SteelTowers.Attribute_Component
{
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
        }

        public override void _ExitTree()
        {
            _value.OnValueChange -= _On_Internal_Value_Change;
        }
        
        public void SetValue(double value)
        {
            var oldValue = _value.Value;
            _value.Value = value;
            var delta = _value.Value - oldValue;
            
            //EmitSignalOnValueChange(_value.Value, oldValue, delta);
            
            //TODO make this check be done in the underlying data type not here and bootstrap up like was done for the OnValueChange signal. 
            //TODO instead of using double.Epsilon directly, multiply it by some small value, like 4, to help with precision issues with large numbers.
            if (double.Abs(_value.Value - _value.Min) <= double.Epsilon) 
            {
                EmitSignalOnValueMin(_value.Value, oldValue, delta);
            } 
            else if (double.Abs(_value.Value - _value.Max) <= double.Epsilon)
            {
                EmitSignalOnValueMax(_value.Value, oldValue, delta);
            }
        }

        public double GetValue()
        {
            return _value.Value;
        }

        public void SetMax(double value)
        {
            var oldValue = _value.Value;
            var oldMax = _value.Max;
            
            _value.Max = value;
            
            var delta = _value.Value - oldValue;
            var deltaMax = _value.Max - oldMax;
            
            EmitSignalOnMaxChange(_value.Max, oldMax, deltaMax);
            
            if (double.Abs(_value.Value - _value.Max) <= double.Epsilon)
            {
                EmitSignalOnValueMax(_value.Value, oldValue, delta);
            }
        }

        public double GetMax()
        {
            return _value.Max;
        }

        public void SetMin(double value)
        {
            var oldValue = _value.Value;
            var oldMin = _value.Min;

            _value.Min = value;
            
            var delta = _value.Value - oldValue;
            var deltaMin = _value.Min - oldMin;
            
            EmitSignalOnMinChange(_value.Min, oldMin, deltaMin);
            
            if (double.Abs(_value.Value - _value.Min) <= double.Epsilon) 
            {
                EmitSignalOnValueMin(_value.Value, oldValue, delta);
            } 
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
        }
    }
}

