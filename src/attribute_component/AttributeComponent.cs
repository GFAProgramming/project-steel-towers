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
        
        public void SetValue(double value)
        {
            var oldValue = _value.Value;
            _value.Value = value;
            var delta = _value.Value - oldValue;
            
            EmitSignalOnValueChange(_value.Value, oldValue, delta);
            
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
            _value.Max = value;
            var delta = _value.Value - oldValue;
            
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
            _value.Min = value;
            var delta = _value.Value - oldValue;
            
            if (double.Abs(_value.Value - _value.Min) <= double.Epsilon) 
            {
                EmitSignalOnValueMin(_value.Value, oldValue, delta);
            } 
        }
        
        public double GetMin()
        {
            return _value.Min;
        }
    }
}

