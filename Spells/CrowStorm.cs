using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueAPI.Projectiles;
using System;
using RogueAPI.Game;

namespace RogueAPI.Spells
{
    public class CrowStorm : SpellDefinition
    {
        public const byte Id = 5;
        public static readonly CrowStorm Instance = new CrowStorm();

        private CrowStorm() : this(Id) { }

        protected CrowStorm(byte id)
            : base(id)
        {
            displayName = "Crow Storm";
            icon = "NukeIcon_Sprite";
            description = string.Format("[Input:{0}]  Hits all enemies on screen. Costly.", (int)Game.InputKeys.PlayerSpell1);

            soundList = new[] { "Cast_Crowstorm" };

            rarity = 3;
            manaCost = 40;
            damageMultiplier = 0.75f;
        }

        protected override bool OnCast(Entity source)
        {
            int activeEnemies = Core.ActiveEnemyCount();

            int maxEnemies = 9;
            if (activeEnemies > maxEnemies)
                activeEnemies = maxEnemies;

            if (activeEnemies <= 0)
                return false;

            //SoundManager.PlaySound("Cast_Crowstorm");
            int distance = 200;
            float angleStep = 360f / activeEnemies;
            float angle = 0f;

            int count = 0;
            foreach (var enemy in Core.GetEnemyList(true))
            {
                var proj = CrowProjectile.Fire(source.GameObject, angle, distance);
                proj.LifeSpan = 10f;
                proj.TurnSpeed = 0.075f;

                Effects.SpellCastEffect.Display(proj.Position, proj.Rotation);

                angle += angleStep;

                if (++count > maxEnemies)
                    break;
            }

            foreach (var enemy in Core.GetTempEnemyList(true))
            {
                var proj = CrowProjectile.Fire(source.GameObject, angle, distance);
                proj.LifeSpan = 99f;
                proj.TurnSpeed = 0.05f;

                Effects.SpellCastEffect.Display(proj.Position, proj.Rotation);

                angle += angleStep;

                if (++count > maxEnemies)
                    break;
            }

            return true;
        }

    }
}
