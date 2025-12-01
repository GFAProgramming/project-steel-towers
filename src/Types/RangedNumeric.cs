using Godot;
using System;
using System.Numerics;

namespace SteelTowers.Types
{
    public partial class RangedNumeric<T> :  RefCounted 
        where T : INumber<T>, IMinMaxValue<T>
    {
        private T _max;

        public T Max
        {
            get => _max;
            set
            {
                _max = value;
                _value = T.Clamp(_value, _min, _max);
            }
        }

        private T _min;
        public T Min
        {
            get => _min;
            set
            {
                _min = value;
                _value = T.Clamp(_value, _min, _max);
            }
        }

        private T _value;
        public T Value
        {
            get => _value;
            set => _value = T.Clamp(value, Min, Max);
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

