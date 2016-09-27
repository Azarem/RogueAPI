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
        public static Func<EffectSpriteInstance> AllocateSprite;

        protected string _spriteName;
        //protected bool _visible;
        protected float _opacity = 1f;
        protected Vector2 _scale = new Vector2(1f);
        protected float _rotation;
        protected bool? _animateFlag;
        protected float _animationDelay;
        protected int _outlineWidth;

        //protected IEnumerable<TweenCommand> _tweenCommands;

        public virtual string SpriteName { get { return _spriteName; } }
        //public virtual bool Visible { get { return _visible; } set { _visible = value; } }
        public virtual float Opacity { get { return _opacity; } set { _opacity = value; } }
        public virtual Vector2 Scale { get { return _scale; } }
        public virtual float Rotation { get { return _rotation; } }
        public virtual bool? AnimationFlag { get { return _animateFlag; } set { _animateFlag = value; } }
        public virtual float AnimationDelay { get { return _animationDelay; } set { _animationDelay = value; } }
        public virtual int OutlineWidth { get { return _outlineWidth; } set { _outlineWidth = value; } }
        protected virtual IList<TweenCommand> TweenCommands { get { return null; } }

        protected virtual EffectSpriteInstance CreateSprite(Vector2 position)
        {
            var sprite = AllocateSprite();
            var spriteName = SpriteName;
            if (spriteName != null)
                sprite.ChangeSprite(SpriteName);

            sprite.Visible = true;
            sprite.Scale = Scale;
            sprite.Opacity = Opacity;
            sprite.Position = position;
            sprite.Rotation = Rotation;
            sprite.OutlineWidth = OutlineWidth;
            sprite.AnimationDelay = AnimationDelay;
            //sprite.TextureColor = Color.White;
            return sprite;
        }

        protected virtual void Animate(EffectSpriteInstance sprite)
        {
            if (AnimationFlag != null)
                sprite.PlayAnimation(AnimationFlag.Value);
        }

        //protected virtual IList<TweenCommand> GetTweenCommands(EffectSpriteInstance sprite)
        //{
        //    return null;
        //}

        protected virtual void ApplyTweens(EffectSpriteInstance sprite, IList<TweenCommand> commands)
        {
            if (commands != null)
                foreach (var t in commands)
                    t.Call(sprite);
        }

        protected virtual void Run(Vector2 position, Action<EffectDisplayEvent> initHandler = null)
        {
            var sprite = CreateSprite(position);
            var evt = new EffectDisplayEvent(this, sprite, TweenCommands);
            initHandler?.Invoke(evt);
            evt.Trigger();
            Animate(sprite);
            ApplyTweens(sprite, evt.TweenCommands);
        }

    }

    //public class EffectDefinition<TArg> : EffectDefinition
    //{
    //    protected override EffectSpriteInstance CreateSprite(Vector2 position)
    //    {
    //        return CreateSprite(position, default(TArg));
    //    }

    //    protected virtual EffectSpriteInstance CreateSprite(Vector2 position, TArg arg)
    //    {
    //        return base.CreateSprite(position);
    //    }

    //    protected override IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj)
    //    {
    //        return GetTweenCommands(obj, default(TArg));
    //    }

    //    protected virtual IEnumerable<TweenCommand> GetTweenCommands(SpriteObj obj, TArg arg)
    //    {
    //        return base.GetTweenCommands(obj);
    //    }

    //    protected override void Run(Vector2 position, GameObj source = null)
    //    {
    //        Run(position, default(TArg), source);
    //    }

    //    protected virtual void Run(Vector2 position, TArg arg, GameObj source = null)
    //    {
    //        var sprite = CreateSprite(position, arg);
    //        var tweens = GetTweenCommands(sprite, arg);
    //        var evt = new EffectDisplayEvent(this, sprite, tweens, source);
    //        evt.Trigger();
    //        Animate(sprite);
    //        ApplyTweens(sprite, evt.TweenCommands);
    //    }
    //}
}
