using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Abilities;
using RogueAPI.Classes;
using RogueAPI.Spells;
using RogueAPI.States;
using RogueAPI.Traits;
using System;
using System.Collections.Generic;

namespace RogueAPI.Game
{
    public class Player : Entity
    {
        private static ClassDefinition _class;
        private static AbilityDefinition _ability;
        private static List<Rune> runes = new List<Rune>();
        internal static Player instance;
        private static TraitDefinition[] traits = new TraitDefinition[0];
        private static StateDefinition _state = IdleState.Instance;
        private static SpellDefinition _spell;

        public static Color SkinColor1 = new Color(231, 175, 131, 255);
        public static Color SkinColor2 = new Color(199, 109, 112, 255);

        public static Player Instance { get { return instance; } set { instance = value; } }
        public static List<Rune> Runes { get { return runes; } }
        public static ClassDefinition Class
        {
            get { return _class; }
            set
            {
                if (_class != null)
                    _class.Deactivate(Instance);

                _class = value;

                if (_class != null)
                    _class.Activate(Instance);
            }
        }

        public Player(PhysicsObjContainer gameObject)
            : base(gameObject)
        {

        }

        public static AbilityDefinition Ability
        {
            get { return _ability; }
            set
            {
                if (_ability != null)
                    _ability.Deactivate(Instance);

                _ability = value;

                if (_ability != null)
                    _ability.Activate(Instance);
            }
        }

        public static StateDefinition State
        {
            get { return _state; }
            set
            {
                if (_state != null)
                    _state.Deactivate(Instance);

                _state = value;

                if (_state != null)
                    _state.Activate(Instance);
            }
        }

        public static SpellDefinition Spell
        {
            get { return _spell; }
            set
            {
                if (_spell != null)
                    _spell.Detach(Instance);

                _spell = value;

                if (_spell != null)
                    _spell.Attach(Instance);
            }
        }

        //NEVER set this to NULL
        public static TraitDefinition[] Traits
        {
            get { return traits; }
            set
            {
                foreach (var t in traits)
                    t.Deactivate(Instance);

                foreach (var t in value)
                    t.Activate(Instance);

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


        //public static event Action<ObjContainer, GameTime> PlayerEffectsUpdating;

        public static event PipeEventHandler<Screen, SkinShaderArgs> RetrievingSkinColor;

        public static event Action<ObjContainer, string> PlayerStyleUpdating;

        public static PipeEventState<Screen, SkinShaderArgs> PipeSkinShaderArgs(Screen source, ObjContainer playerSprite)
        {
            var args = new PipeEventState<Screen, SkinShaderArgs>(source, new SkinShaderArgs() { PlayerSprite = playerSprite });

            if (RetrievingSkinColor != null)
                RetrievingSkinColor(args);

            return args;
        }

        //public static void UpdatePlayerEffects(ObjContainer player, GameTime gameTime)
        //{
        //    if (PlayerEffectsUpdating != null)
        //        PlayerEffectsUpdating(player, gameTime);
        //}

        public static void UpdatePlayerStyle(ObjContainer player, string animationType)
        {
            if (PlayerStyleUpdating != null)
                PlayerStyleUpdating(player, animationType);
        }

        public static void StopAllSpellsAndAbilities()
        {
            Spell?.Deactivate(true);
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
