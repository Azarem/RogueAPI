using System;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Projectiles;
using System.Collections.Generic;

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
        //public static Action<EffectType, GameObj, Vector2?> AttachEffect;
        //public static Func<ProjectileDefinition, GameObj, GameObj, ProjectileObj> FireProjectile;
        public static Func<IEnumerable<BlankObj>> GetCurrentRoomTerrainObjects;
        public static Action<PhysicsObj> AttachPhysicsObject;
        public static Func<int> ActiveEnemyCount;
        public static Func<bool, IEnumerable<PhysicsObjContainer>> GetEnemyList;
        public static Func<bool, IEnumerable<PhysicsObjContainer>> GetTempEnemyList;
        public static Func<IEnumerable<ProjectileObj>> GetActiveProjectiles;
        public static Action<int, string, Color, Vector2> DisplayNumberString;

        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenEntered;
        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenExited;
        //public static event Action<string, Screen, PhysicsObjContainer, object> ScreenDraw;

        private static bool _isInitialized = false;

        public static void Initialize()
        {
            if (_isInitialized)
                throw new InvalidOperationException("RogueAPI core has already been initialized.");

            //Perform other initialization here

            //Load plugins
            Plugins.PluginInitializer.Initialize();

            //Attribute initializers
            //InitializeAttribute.ProcessAll();
        }

        public static void OnContentLoaded()
        {
            if (ContentLoaded != null)
                ContentLoaded();
        }

        public static TList[] Copy<TList>(this IList<TList> list)
        {
            if (list == null)
                return null;

            var len = list.Count;
            var ix = -1;
            var newArr = new TList[len];

            while (++ix < len)
                newArr[ix] = list[ix];

            return newArr;
        }

        public static int ToBitFlag(this int value)
        {
            return 1 << value;
        }

        public static int FromBitFlag(this int value)
        {
            int index = -1;
            while(value > 0)
            {
                value >>= 1;
                index++;
            }

            return index;
        }

        public static bool IsPlayer(this GameObj obj)
        {
            return obj == Game.Player.Instance.GameObject;
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


    //public enum EffectType
    //{
    //    BlackSmoke,
    //    ChestSparkle,
    //    QuestionMark,
    //    FahRoDus
    //}
}
