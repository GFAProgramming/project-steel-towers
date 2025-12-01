using Godot;
using System;
using System.Numerics;

namespace SteelTowers.Types
{
    public partial class RangedNumeric<T> :  RefCounted 
        where T : INumber<T>, IMinMaxValue<T>
    {
        public event EventHandler<OnValueChangeArgs> OnValueChange;
        public event EventHandler<OnValueChangeArgs> OnMaxChange;
        public event EventHandler<OnValueChangeArgs> OnMinChange;

        public sealed class OnValueChangeArgs : EventArgs
        {
            public T NewValue { get; set; }
            public T OldValue { get; set; }
            public T Delta { get; set; }
        }
        
        private T _max;

        public T Max
        {
            get => _max;
            set
            {
                var oldMax = _max;
                _max = value;
                var delta = _max - oldMax;
                
                Value = T.Clamp(_value, _min, _max);

                OnMaxChange?.Invoke(this,
                    new OnValueChangeArgs()
                    {
                        NewValue = _max, OldValue = oldMax, Delta = delta
                    }
                );
            }
        }

        private T _min;
        public T Min
        {
            get => _min;
            set
            {
                var oldMin = _min;
                _min = value;
                var delta = _min - oldMin;
                
                Value = T.Clamp(_value, _min, _max);

                OnMinChange?.Invoke(this,
                    new OnValueChangeArgs()
                    {
                        NewValue = _min, OldValue = oldMin, Delta = delta
                    }
                );
            }
        }

        private T _value;
        public T Value
        {
            get => _value;
            set 
                {
                    var oldValue = _value;
                    _value = T.Clamp(value, Min, Max);
                    var delta = _value - oldValue;

                    OnValueChange?.Invoke(this, 
                        new OnValueChangeArgs()
                            {NewValue=_value, OldValue=oldValue , Delta=delta}
                        );
                }
        }

        public RangedNumeric()
        {
            Max = default(T);
            Min = default(T);
            Value = default(T);
            
            // This doesn't seem to want to work how I'd want it to. Causes problems in the editor.
            // Max = T.MaxValue;
            // Min = T.MinValue;
        }

        public RangedNumeric(T value, T min, T max)
        {
            Value = value;
            Min = min;
            Max = max;
        }

    }
}

