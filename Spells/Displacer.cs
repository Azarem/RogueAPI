using RogueAPI.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DS2DEngine;
using RogueAPI.Projectiles;
using System;

namespace RogueAPI.Spells
{
    public class Displacer : SpellDefinition
    {
        public const byte Id = 7;
        public static readonly Displacer Instance = new Displacer();

        private Displacer() : this(Id) { }

        protected Displacer(byte id)
            : base(id)
        {
            displayName = "Displacer";
            icon = "DisplacerIcon_Sprite";
            description = string.Format("[Input:{0}]  Sends out a marker which teleports you.", (int)Game.InputKeys.PlayerSpell1);
         
            rarity = 0;
            manaCost = 10;
            damageMultiplier = 0f;
        }

        protected override bool OnCast(Entity source)
        {
            var proj = DisplacerProjectile.Fire(source.GameObject);

            proj.Rotation = 0;
            RunTeleport(proj);
            proj.KillProjectile();

            Effects.SpellCastEffect.Display(proj.Position, proj.Rotation, true);

            return true;
        }

        public static void RunTeleport(ProjectileObj proj)
        {
            var source = proj.Source as PhysicsObjContainer;

            int closestDistance = int.MaxValue;
            BlankObj closestObj = null;
            bool flip = source.Flip != SpriteEffects.None;

            foreach (BlankObj terrainObj in Core.GetCurrentRoomTerrainObjects())
            {
                if (terrainObj.Bounds.Top >= proj.Bounds.Bottom || terrainObj.Bounds.Bottom <= proj.Bounds.Top)
                    continue;

                var point = Vector2.Zero;
                float distance = float.MaxValue;

                Vector2 start1 = Vector2.Zero, end1 = Vector2.Zero;
                Func<Rectangle, float, Vector2, Vector2> startFunc = null, endFunc = null;

                if (!flip)
                {
                    if (terrainObj.X <= proj.X)
                        continue;

                    if (terrainObj.Rotation != 0)
                    {
                        start1 = proj.Position;
                        end1 = new Vector2(proj.X + 6600f, proj.Y);
                        if (terrainObj.Rotation < 0f)
                        {
                            startFunc = CollisionMath.UpperLeftCorner;
                            endFunc = CollisionMath.UpperRightCorner;
                        }
                        else
                        {
                            startFunc = CollisionMath.LowerLeftCorner;
                            endFunc = CollisionMath.UpperLeftCorner;
                        }
                    }
                }
                else
                {
                    if (terrainObj.X >= proj.X)
                        continue;

                    if (terrainObj.Rotation != 0)
                    {
                        start1 = new Vector2(proj.X - 6600f, proj.Y);
                        end1 = proj.Position;
                        if (terrainObj.Rotation < 0f)
                        {
                            startFunc = CollisionMath.UpperRightCorner;
                            endFunc = CollisionMath.LowerRightCorner;
                        }
                        else
                        {
                            startFunc = CollisionMath.UpperLeftCorner;
                            endFunc = CollisionMath.UpperRightCorner;
                        }
                    }
                }

                if (startFunc != null)
                {
                    var bounds = new Rectangle((int)terrainObj.X, (int)terrainObj.Y, terrainObj.Width, terrainObj.Height);
                    var start2 = startFunc(bounds, terrainObj.Rotation, Vector2.Zero);
                    var end2 = endFunc(bounds, terrainObj.Rotation, Vector2.Zero);
                    point = CollisionMath.LineToLineIntersect(start1, end1, start2, end2);
                }

                if (point == Vector2.Zero)
                    distance = !flip ? (terrainObj.Bounds.Left - proj.Bounds.Right) : (proj.Bounds.Left - terrainObj.Bounds.Right);
                else
                    distance = !flip ? (point.X - proj.X) : (proj.X - point.X);

                if (distance < closestDistance)
                {
                    closestDistance = (int)distance;
                    closestObj = terrainObj;
                }
            }

            if (closestObj != null)
            {
                var newOffset = closestDistance - (closestObj.Rotation != 0f ? source.Width : source.TerrainBounds.Width) / 2f;
                if (flip)
                    newOffset = -newOffset;

                source.X += newOffset;
            }
        }

    }
}
