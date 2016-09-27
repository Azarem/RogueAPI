using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using Tweener;

namespace RogueAPI.Spells
{
    public class RapidDagger : SpellDefinition
    {
        public const byte Id = 14;
        public static readonly RapidDagger Instance = new RapidDagger();

        private RapidDagger() : this(Id) { }

        protected RapidDagger(byte id)
            : base(id)
        {
            displayName = "Rapid Dagger";
            icon = "RapidDaggerIcon_Sprite";
            description = string.Format("[Input:{0}]  Fire a barrage of daggers.", (int)Game.InputKeys.PlayerSpell1);

            rarity = 1;
            manaCost = 30;
            damageMultiplier = 0.75f;
        }

        protected override bool OnCast(Entity source)
        {
            var obj = source.GameObject;
            Tween.RunFunction(0f, this, "CastDagger", obj, false);
            Tween.RunFunction(0.05f, this, "CastDagger", obj, true);
            Tween.RunFunction(0.1f, this, "CastDagger", obj, true);
            Tween.RunFunction(0.15f, this, "CastDagger", obj, true);
            Tween.RunFunction(0.2f, this, "CastDagger", obj, true);
            return true;
        }

        protected void CastDagger(GameObj source, bool randomize)
        {
            SoundManager.PlaySound("Cast_Dagger");
            var proj = Projectiles.SlowDaggerProjectile.Fire(source, randomize);
            Effects.SpellCastEffect.Display(source.Position, source.Rotation, false);
        }
    }
}
