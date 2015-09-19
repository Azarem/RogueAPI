using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;

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
    }

    public enum EffectType
    {
        BlackSmoke,
        ChestSparkle,
        QuestionMark
    }
}
