using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Effects
{
    public class EffectDefinition
    {
        public static Func<SpriteObj> AllocateSprite;

        protected string _spriteName;
        //protected bool _visible;
        protected float _opacity = 1f;
        protected Vector2 _scale = new Vector2(1f);
        protected float _rotation;
        protected bool? _animateFlag;
        protected float _animationDelay;
        protected int _outlineWidth;
        //protected IEnumerable<TweenCommand> _tweenCommands;

        public virtual string SpriteName { get { return _spriteName; } set { _spriteName = value; } }
        //public virtual bool Visible { get { return _visible; } set { _visible = value; } }
        public virtual float Opacity { get { return _opacity; } set { _opacity = value; } }
        public virtual Vector2 Scale { get { return _scale; } set { _scale = value; } }
        public virtual float Rotation { get { return _rotation; } set { _rotation = value; } }
        public virtual bool? AnimationFlag { get { return _animateFlag; } set { _animateFlag = value; } }
        public virtual float AnimationDelay { get { return _animationDelay; } set { _animationDelay = value; } }
        public virtual int OutlineWidth { get { return _outlineWidth; } set { _outlineWidth = value; } }
        //public virtual IEnumerable<TweenCommand> TweenCommands { get { return _tweenCommands; } set { _tweenCommands = value; } }

        protected virtual SpriteObj CreateSprite(Vector2 position)
        {
            var sprite = AllocateSprite();
            sprite.ChangeSprite(SpriteName);
            sprite.Visible = true;
            sprite.Scale = Scale;
            sprite.Opacity = Opacity;
            sprite.Position = position;
            sprite.Rotation = Rotation;
            sprite.OutlineWidth = OutlineWidth;
            sprite.AnimationDelay = AnimationDelay;
            return sprite;
        }

        protected virtual void Animate(SpriteObj sprite)
        {
            if (AnimationFlag != null)
                sprite.PlayAnimation(AnimationFlag.Value);
        }

        protected virtual IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj)
        {
            return null;
        }

        protected virtual void ApplyTweens(SpriteObj sprite, IEnumerable<TweenCommand> commands)
        {
            if (commands != null)
                foreach (var t in commands)
                    t.Call(sprite);
        }

        protected virtual void Run(Vector2 position)
        {
            var sprite = CreateSprite(position);
            var tweens = GetTweenCommands(sprite);
            var args = new EffectDisplayEvent(this, sprite, tweens);
            args.Trigger();
            Animate(sprite);
            ApplyTweens(sprite, args.TweenCommands);
        }

    }

    public class EffectDefinition<TArg> : EffectDefinition
    {
        protected override SpriteObj CreateSprite(Vector2 position)
        {
            return CreateSprite(position, default(TArg));
        }

        protected virtual SpriteObj CreateSprite(Vector2 position, TArg arg)
        {
            return base.CreateSprite(position);
        }

        protected override IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj)
        {
            return GetTweenCommands(obj, default(TArg));
        }

        protected virtual IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj, TArg arg)
        {
            return base.GetTweenCommands(obj);
        }

        protected override void Run(Vector2 position)
        {
            Run(position, default(TArg));
        }

        protected virtual void Run(Vector2 position, TArg arg)
        {
            var sprite = CreateSprite(position, arg);
            var tweens = GetTweenCommands(sprite, arg);
            var args = new EffectDisplayEvent(this, sprite, tweens);
            args.Trigger();
            Animate(sprite);
            ApplyTweens(sprite, args.TweenCommands);
        }
    }
}
