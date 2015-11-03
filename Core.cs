using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Projectiles;

namespace RogueAPI
{
    public delegate void PipeEventHandler<TSource, TTarget>(PipeEventState<TSource, TTarget> args);

    public class PipeEventState<TSource, TTarget>
    {
        public TSource Sender;
        public TTarget Target;
        //public bool Cancel;
        public bool Handled;

        public PipeEventState() { }
        public PipeEventState(TSource sender, TTarget target)
        {
            Sender = sender;
            Target = target;
        }
    }

    public static class Core
    {
        public static event Action ContentLoaded;
        public static Func<byte, Enemies.EnemyDifficulty, PhysicsObjContainer> CreateEnemy;
        public static Action<PhysicsObjContainer> AttachEnemyToCurrentRoom;
        public static Action<EffectType, GameObj, Vector2?> AttachEffect;
        public static Func<ProjectileDefinition, GameObj, GameObj, ProjectileObj> FireProjectile;

        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenEntered;
        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenExited;
        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenDraw;

        public static void Initialize()
        {
            //Perform other initialization here

            //Load plugins
            Plugins.PluginInitializer.Initialize();
        }

        public static void OnContentLoaded()
        {
            if (ContentLoaded != null)
                ContentLoaded();
        }

        //public static void OnScreenEntered(string type, Screen screen, PhysicsObjContainer player, object args)
        //{
        //    if (ScreenEntered != null)
        //        ScreenEntered(type, screen, player, args);
        //}

        //public static void OnScreenExited(string type, Screen screen, PhysicsObjContainer player, object args)
        //{
        //    if (ScreenExited != null)
        //        ScreenExited(type, screen, player, args);
        //}

        //public static void OnScreenDraw(string type, Screen screen, PhysicsObjContainer player, object args)
        //{
        //    if (ScreenDraw != null)
        //        ScreenDraw(type, screen, player, args);
        //}
    }


    public enum EffectType
    {
        BlackSmoke,
        ChestSparkle,
        QuestionMark,
        FahRoDus
    }
}
