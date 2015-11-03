using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Stats
{
    public class StatDefinition
    {
        protected bool _recalculate;

        public float BaseValue;
        public int BonusValue;
        public float BonusMultiplier;
        public float MinValue;

        protected float _currentValue;
        public float CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > MaxValue)
                    value = MaxValue;
                _currentValue = value;
            }
        }

        protected float _maxValue;
        public virtual float MaxValue
        {
            get
            {
                if (_recalculate)
                {
                    var calc = new StatCalculation() { BaseValue = BaseValue + (BonusValue * BonusMultiplier) };
                    if (CalculatingMaxValue != null)
                        CalculatingMaxValue(calc);

                    var val = calc.BaseValue * calc.Multiplier + calc.ExtraValue;

                    if (val < MinValue)
                        val = MinValue;

                    _recalculate = false;
                    _maxValue = val;
                }

                return _maxValue;
            }
        }


        protected event Action<StatCalculation> CalculatingMaxValue;

        public void AddHandler(Action<StatCalculation> handler)
        {
            CalculatingMaxValue += handler;
            Invalidate();
        }

        public void RemoveHandler(Action<StatCalculation> handler)
        {
            CalculatingMaxValue -= handler;
            Invalidate();
        }

        public virtual void Invalidate()
        {
            _recalculate = true;
        }


        public static readonly Dictionary<byte, Type> All = new Dictionary<byte, Type>() {
            { HealthStat.Id, typeof(HealthStat) },
            { ManaStat.Id, typeof(ManaStat) },
            { ManaCostStat.Id, typeof(ManaCostStat) }
        };
    }

    public class StatCalculation
    {
        public float BaseValue;
        public float Multiplier = 1.0f;
        public float ExtraValue;
    }
}
