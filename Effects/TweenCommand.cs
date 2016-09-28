using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweener;

namespace RogueAPI.Effects
{

    public class TweenCommand
    {
        public object Target;
        public float Duration;
        public Easing Easing;
        public string[] Properties;
        public float[] InitialValues;
        public TweenEndHandler EndHandler;
        public bool Offset;

        protected static Action<object, object> SetInitialValues = typeof(TweenObject).GetField("_initialValues").SetValue;

        protected TweenCommand() { }

        public TweenCommand(bool offset, float duration, Easing easing, params string[] properties) : this(null, offset, duration, easing, properties) { }
        public TweenCommand(object target, bool offset, float duration, Easing easing, params string[] properties)
        {
            Target = target;
            Offset = offset;
            Duration = duration;
            Easing = easing;
            Properties = properties;
        }

        public void Call(object target = null)
        {
            var tween = Offset
                ? Tween.By(Target ?? target, Duration, Easing, Properties)
                : Tween.To(Target ?? target, Duration, Easing, Properties);

            if (InitialValues != null)
                SetInitialValues(this, InitialValues.Copy());

            if (EndHandler != null)
                if (EndHandler.Target is Type)
                    tween.EndHandler(EndHandler.Target as Type, EndHandler.Function, EndHandler.Arguments);
                else
                    tween.EndHandler(EndHandler.Target ?? target, EndHandler.Function, EndHandler.Arguments);
        }

        public TweenCommand Clone()
        {
            return new TweenCommand()
            {
                Target = Target,
                Duration = Duration,
                Easing = Easing,
                EndHandler = EndHandler,
                InitialValues = InitialValues.Copy(),
                Offset = Offset,
                Properties = Properties.Copy()
            };
        }
    }

    public class TweenEndHandler
    {
        public object Target;
        public string Function;
        public object[] Arguments;

        public TweenEndHandler(string function, params object[] arguments) : this((object)null, function, arguments) { }
        public TweenEndHandler(object target, string function, params object[] arguments)
        {
            Target = target;
            Function = function;
            Arguments = arguments;
        }
    }

}
