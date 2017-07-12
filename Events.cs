using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Projectiles;
using RogueAPI.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI
{
    public interface IEventArgs
    {

    }

    public interface IEventArgs<TSender> : IEventArgs where TSender : class
    {
        TSender Sender { get; }
    }

    public interface IMapScreenEventArgs : IEventArgs<Screen>
    {
        bool IsTeleporter { get; }
    }

    public interface IScreenDrawEventArgs : IEventArgs<Screen>
    {
        Camera2D Camera { get; }
        GameTime GameTime { get; }
    }

    public abstract class EventArgs<TSender> : IEventArgs where TSender : class
    {
        protected internal TSender _sender;
        public TSender Sender { get { return _sender; } }

        protected EventArgs(TSender sender)
        {
            _sender = sender;
        }
    }


    public abstract class ScreenDrawEventArgs : EventArgs<Screen>, IScreenDrawEventArgs
    {
        protected internal Camera2D _camera;
        protected internal GameTime _gameTime;

        public Camera2D Camera { get { return _camera; } }
        public GameTime GameTime { get { return _gameTime; } }

        public ScreenDrawEventArgs(Screen sender, Camera2D camera, GameTime gameTime)
            : base(sender)
        {
            _camera = camera;
            _gameTime = gameTime;
        }
    }

    public class MapDrawEventArgs : ScreenDrawEventArgs, IMapScreenEventArgs, IScreenDrawEventArgs
    {
        protected internal bool _isTeleporter;
        public bool IsTeleporter { get { return _isTeleporter; } }

        public MapDrawEventArgs(Screen sender, Camera2D camera, GameTime gameTime, bool isTeleporter)
            : base(sender, camera, gameTime)
        {
            _isTeleporter = isTeleporter;
        }
    }

    public class MapEnterEventArgs : EventArgs<Screen>, IMapScreenEventArgs
    {
        protected internal bool _isTeleporter;
        public bool IsTeleporter { get { return _isTeleporter; } }
        public bool DrawNothing { get; set; }


        public MapEnterEventArgs(Screen sender, bool isTeleporter, bool drawNothing)
            : base(sender)
        {
            _isTeleporter = isTeleporter;
            DrawNothing = drawNothing;
        }
    }

    public class EnemyHitEventArgs : IEventArgs
    {
        public readonly PhysicsObjContainer Enemy;
        public readonly int Damage;
        public readonly bool WasPlayer;
        public float KnockbackForce { get; set; }

        public EnemyHitEventArgs(PhysicsObjContainer enemy, int damage, bool wasPlayer, float knockbackForce)
        {
            Enemy = enemy;
            Damage = damage;
            WasPlayer = wasPlayer;
            KnockbackForce = knockbackForce;
        }
    }

    //public class EnemyCollisionEvent : IEventArgs
    //{
    //    public readonly PhysicsObjContainer Enemy;
    //    public readonly IPhysicsObj Source;
    //    public int Damage { get; set; }
    //    public bool Handled { get; set; }

    //    public EnemyCollisionEvent(PhysicsObjContainer enemy, IPhysicsObj source, int damage)
    //    {
    //        Enemy = enemy;
    //        Source = source;
    //        Damage = damage;
    //    }
    //}

    public class MapExitEventArgs : EventArgs<Screen>
    {
        public MapExitEventArgs(Screen sender)
            : base(sender)
        {

        }
    }

    public class PlayerDrawEventArgs : IEventArgs
    {
        public readonly GameObj Player;
        public readonly Camera2D Camera;
        public bool IsPreDraw { get; set; }

        public PlayerDrawEventArgs(GameObj player, Camera2D camera, bool isPreDraw)
        {
            Player = player;
            Camera = camera;
            IsPreDraw = isPreDraw;
        }
    }

    public class LevelEnterEventArgs : EventArgs<Screen>
    {
        protected internal ObjContainer _player;
        public ObjContainer Player { get { return _player; } }

        protected internal ObjectChain<Game.LevelRenderStep, Game.RenderStep> _renderChain;
        public ObjectChain<Game.LevelRenderStep, Game.RenderStep> RenderChain { get { return _renderChain; } }

        public LevelEnterEventArgs(Screen sender, ObjContainer player, ObjectChain<Game.LevelRenderStep, Game.RenderStep> renderChain)
            : base(sender)
        {
            _player = player;
            _renderChain = renderChain;
        }
    }

    public class KeyPressEventArgs : IEventArgs
    {
        protected internal Game.InputKeys _key;

        public Game.InputKeys Key { get { return _key; } }

        public KeyPressEventArgs(Game.InputKeys key)
        {
            _key = key;
        }
    }

    public class InputEventHandler : IEventArgs
    {
        public readonly Game.InputFlags Pressed;
        public readonly Game.InputFlags NewlyPressed;

        public InputEventHandler()
        {
            Pressed = Game.InputManager.PressedFlags;
            NewlyPressed = Game.InputManager.NewlyPressedFlags;
        }
    }

    public class PlayerUpdateEvent : IEventArgs
    {
        public readonly float ElapsedSeconds;
        public readonly Game.Player Player;
        public readonly bool UpdateEffects;

        public PlayerUpdateEvent(GameTime gameTime, bool updateEffects)
        {
            ElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            UpdateEffects = updateEffects;
            Player = Game.Player.Instance;
        }
    }

    public class SpellCastEvent : EventArgs<GameObj>
    {
        protected internal ProjectileObj _projectile;
        protected internal SpellDefinition _spell;

        public ProjectileObj Projectile { get { return _projectile; } }
        public SpellDefinition Spell { get { return _spell; } }

        public SpellCastEvent(GameObj source, ProjectileObj projectile, SpellDefinition spell) : base(source)
        {
            _projectile = projectile;
            _spell = spell;
        }
    }

    public class LevelExitEventArgs : EventArgs<Screen>
    {
        protected internal ObjContainer _player;
        public ObjContainer Player { get { return _player; } }

        public LevelExitEventArgs(Screen sender, ObjContainer player)
            : base(sender)
        {
            _player = player;
        }
    }

    public class ProjectileFireEvent : EventArgs<GameObj>
    {
        protected internal Projectiles.ProjectileObj _projectile;
        protected internal Projectiles.ProjectileDefinition _projDef;
        public Projectiles.ProjectileObj Projectile { get { return _projectile; } }
        public Projectiles.ProjectileDefinition ProjectileDefinition { get { return _projDef; } }

        public ProjectileFireEvent(GameObj sender, Projectiles.ProjectileDefinition definition, Projectiles.ProjectileObj projectile)
            : base(sender)
        {
            _projDef = definition;
            _projectile = projectile;
        }
    }

    public class EffectDisplayEvent : IEventArgs
    {
        public readonly Effects.EffectDefinition Effect;
        public readonly Effects.EffectSpriteInstance Sprite;
        //public readonly GameObj Source;
        public IList<Effects.TweenCommand> TweenCommands;

        public EffectDisplayEvent(Effects.EffectDefinition effect, Effects.EffectSpriteInstance sprite, IList<Effects.TweenCommand> tweenCommands)
        {
            Effect = effect;
            Sprite = sprite;
            TweenCommands = tweenCommands;
            //Source = source;
        }
    }

    public static class Event
    {
        public static void AddHandler<TArgs>(Action<TArgs> handler) where TArgs : class
        {
            Event<TArgs>.Handler += handler;
        }

        public static void RemoveHandler<TArgs>(Action<TArgs> handler) where TArgs : class
        {
            Event<TArgs>.Handler -= handler;
        }

        public static void Trigger<TArgs>(this TArgs arg) where TArgs : class, IEventArgs
        {
            Event<TArgs>.Trigger(arg);
        }
    }

    public static class Event<T> where T : class
    {
        public static event Action<T> Handler;

        public static void Trigger(T args)
        {
            Handler?.Invoke(args);
        }
    }
}
