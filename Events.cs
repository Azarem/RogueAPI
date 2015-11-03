using DS2DEngine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI
{
    public interface IEventArgs<TSender> where TSender : class
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

    public abstract class EventArgs<TSender> where TSender : class
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

    public class MapExitEventArgs : EventArgs<Screen>
    {
        public MapExitEventArgs(Screen sender)
            : base(sender)
        {

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

    public class KeyPressEventArgs
    {
        protected internal Game.InputKeys _key;

        public Game.InputKeys Key { get { return _key; } }

        public KeyPressEventArgs(Game.InputKeys key)
        {
            _key = key;
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
            :base(sender)
        {
            _projDef = definition;
            _projectile = projectile;
        }
    }

    public static class Event<T> where T : class
    {
        public static event Action<T> Handler;

        public static void Trigger(T args)
        {
            if (Handler != null)
                Handler(args);
        }
    }
}
