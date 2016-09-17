using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Conflux : SpellDefinition
    {
        public const byte Id = 12;
        public static readonly Conflux Instance = new Conflux();

        private Conflux() : this(Id) { }

        protected Conflux(byte id)
            : base(id)
        {
            displayName = "Conflux";
            icon = "BounceIcon_Sprite";
            description = string.Format("[Input:{0}]  Launches orbs that bounce everywhere.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_Dagger" };

            rarity = 3;
            manaCost = 30;
            damageMultiplier = 0.4f;
        }

        protected override bool OnCast(Entity source)
        {
            var angleOffset = 0f;

            for (int i = 0; i < 4; i++)
            {
                Vector2 sourceAnchor;
                switch (i)
                {
                    case 0: sourceAnchor = new Vector2(-10f, -10f); break;
                    case 1: sourceAnchor = new Vector2(10f, -10f); break;
                    case 2: sourceAnchor = new Vector2(10f, 10f); break;
                    default: sourceAnchor = new Vector2(-10f, 10f); break;
                }

                var proj = ConfluxProjectile.Fire(source.GameObject, angleOffset, sourceAnchor);
                //proj.Orientation = MathHelper.ToRadians(angle);
                angleOffset += 90f;
            }

            return true;
        }
    }
}
