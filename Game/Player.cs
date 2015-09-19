using System;
using System.Collections.Generic;
using System.Linq;
using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Classes;
using RogueAPI.Player;
using RogueAPI.Traits;

namespace RogueAPI.Game
{
    public class Player : Entity
    {
        private static PlayerStatus status = new PlayerStatus();
        private static ClassDefinition _class;
        private static List<Rune> runes = new List<Rune>();
        internal static PhysicsObjContainer instance;
        private static TraitDefinition[] traits = new TraitDefinition[0];

        public static Color SkinColor1 = new Color(231, 175, 131, 255);
        public static Color SkinColor2 = new Color(199, 109, 112, 255);

        public static PhysicsObjContainer Instance { get { return instance; } set { instance = value; } }
        public static PlayerStatus Status { get { return status; } }
        public static List<Rune> Runes { get { return runes; } }
        public static ClassDefinition Class
        {
            get { return _class; }
            set
            {
                if (_class != null)
                    _class.Deactivate();

                _class = value;

                if (_class != null)
                    _class.Activate();
            }
        }

        //NEVER set this to NULL
        public static TraitDefinition[] Traits
        {
            get { return traits; }
            set
            {
                foreach (var t in traits.Except(value))
                    t.Deactivate();

                foreach (var t in value.Except(traits))
                    t.Activate();

                traits = value;
            }
        }

        public static void SetTraitVector(Vector2 traits)
        {
            List<TraitDefinition> list = new List<TraitDefinition>(2);
            if (traits.X != 0)
                list.Add(TraitDefinition.GetById((byte)traits.X));
            if (traits.Y != 0)
                list.Add(TraitDefinition.GetById((byte)traits.Y));
            Traits = list.ToArray();
        }

        public static void SetClassId(byte value)
        {
            Class = ClassDefinition.GetById(value);
        }

        public static event Action<object> CalculatingStat;

        public static event Action<ObjContainer, GameTime> PlayerEffectsUpdating;

        public static event PipeEventHandler<Screen, SkinShaderArgs> RetrievingSkinColor;

        public static PipeEventState<Screen, SkinShaderArgs> PipeSkinShaderArgs(Screen source, ObjContainer playerSprite)
        {
            var args = new PipeEventState<Screen, SkinShaderArgs>(source, new SkinShaderArgs() { PlayerSprite = playerSprite });

            if (RetrievingSkinColor != null)
                RetrievingSkinColor(args);

            return args;
        }

        public static void UpdatePlayerEffects(ObjContainer player, GameTime gameTime)
        {
            if (PlayerEffectsUpdating != null)
                PlayerEffectsUpdating(player, gameTime);
        }

        //public static int MaxHealth
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //}

        public static void CalculateStat(object statDef)
        {
            if (CalculatingStat != null)
                CalculatingStat(statDef);
        }

        public class SkinShaderArgs
        {
            public ObjContainer PlayerSprite;
            public float Opacity = 1;
            public Color ColorSwappedOut1 = Player.SkinColor1;
            public Color ColorSwappedIn1 = Player.SkinColor1;
            public Color ColorSwappedOut2 = Player.SkinColor2;
            public Color ColorSwappedIn2 = Player.SkinColor2;
        }

    }
}
