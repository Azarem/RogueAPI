using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueAPI.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DS2DEngine;
using RogueAPI.Projectiles;

namespace RogueAPI.Spells
{
    public class Displacer : SpellDefinition
    {
        public const byte Id = 7;
        public static readonly Displacer Instance = new Displacer();

        private Displacer()
            : this(Id)
        {
            DisplayName = "Dagger";
            Icon = "DaggerIcon_Sprite";
            Description = string.Format("[Input:{0}]  Fires a dagger directly in front of you.", (int)Game.InputKeys.PlayerSpell1);
        }

        protected Displacer(byte id)
            : base(id)
        {
            MiscValue1 = 0f;
            MiscValue2 = 0f;
            Rarity = 1;
            ManaCost = 10;
            DamageMultiplier = 1.0f;
        }

        protected override void CastSpell(Entity source, ProjectileInstance projectile, bool isMega)
        {
            base.CastSpell(source, projectile, isMega);


            var gameObj = source.GameObject;
            var projObj = projectile.Source;

            projObj.Rotation = 0;

            int closestDistance = int.MaxValue;
            BlankObj closestObject = null;

            Vector2 pos;

            foreach (BlankObj terrainObj in Core.GetCurrentRoomTerrainObjects())
            {
                pos = Vector2.Zero;
                float distance = float.MaxValue;

                //Get object bounds (non-rotated)
                var bounds = new Rectangle((int)terrainObj.X, (int)terrainObj.Y, terrainObj.Width, terrainObj.Height);

                if (gameObj.Flip == SpriteEffects.None)
                {
                    if (terrainObj.X > projObj.X && terrainObj.Bounds.Top < projObj.Bounds.Bottom && terrainObj.Bounds.Bottom > projObj.Bounds.Top)
                    {
                        if (terrainObj.Rotation < 0f)
                            pos = CollisionMath.LineToLineIntersect(projObj.Position, new Vector2(projObj.X + 6600f, projObj.Y), CollisionMath.UpperLeftCorner(bounds, terrainObj.Rotation, Vector2.Zero), CollisionMath.UpperRightCorner(bounds, terrainObj.Rotation, Vector2.Zero));
                        else if (terrainObj.Rotation > 0f)
                            pos = CollisionMath.LineToLineIntersect(projObj.Position, new Vector2(projObj.X + 6600f, projObj.Y), CollisionMath.LowerLeftCorner(bounds, terrainObj.Rotation, Vector2.Zero), CollisionMath.UpperLeftCorner(bounds, terrainObj.Rotation, Vector2.Zero));

                        distance = pos == Vector2.Zero 
                            ? terrainObj.Bounds.Left - projObj.Bounds.Right 
                            : pos.X - projObj.X;
                    }
                }
                else if (terrainObj.X < projObj.X && terrainObj.Bounds.Top < projObj.Bounds.Bottom && terrainObj.Bounds.Bottom > projObj.Bounds.Top)
                {
                    if (terrainObj.Rotation < 0f)
                        pos = CollisionMath.LineToLineIntersect(new Vector2(projObj.X - 6600f, projObj.Y), projObj.Position, CollisionMath.UpperRightCorner(bounds, terrainObj.Rotation, Vector2.Zero), CollisionMath.LowerRightCorner(bounds, terrainObj.Rotation, Vector2.Zero));
                    else if (terrainObj.Rotation > 0f)
                        pos = CollisionMath.LineToLineIntersect(new Vector2(projObj.X - 6600f, projObj.Y), projObj.Position, CollisionMath.UpperLeftCorner(bounds, terrainObj.Rotation, Vector2.Zero), CollisionMath.UpperRightCorner(bounds, terrainObj.Rotation, Vector2.Zero));

                    distance = pos == Vector2.Zero 
                        ? projObj.Bounds.Left - terrainObj.Bounds.Right 
                        : projObj.X - pos.X;
                }

                if (distance < closestDistance)
                {
                    closestDistance = (int)distance;
                    closestObject = terrainObj;
                }
            }

            if (closestObject != null)
            {
                var offsetX = closestDistance - (closestObject.Rotation != 0f ? gameObj.Width : gameObj.TerrainBounds.Width) / 2f;
                if (gameObj.Flip != SpriteEffects.None)
                    offsetX = -offsetX;

                gameObj.X += offsetX;
                
            }

            //projObj.KillProjectile();
        }

    }
}
