using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using RogueAPI.Projectiles;
using Tweener;

namespace RogueAPI.Abilities
{
    public class FahRoDus : AbilityDefinition
    {
        public static readonly FahRoDus Instance = new FahRoDus();

        public float Magnitude;

        private ProjectileDefinition Projectile = new ProjectileDefinition()
        {
            SpriteName = "SpellShout_Sprite",
            IsWeighted = false,
            Lifespan = 2f,
            CollidesWith1Ways = false,
            CollidesWithTerrain = false,
            DestroysWithEnemy = false,
            DestroysWithTerrain = false,
            Damage = 0,
            Scale = Vector2.One
        };


        protected FahRoDus()
        {
            ManaCost = 20;
            IsCastable = true;
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            Event<LevelEnterEventArgs>.Handler += LevelEntered;
        }

        protected internal override void Deactivate(Player player)
        {
            Event<LevelEnterEventArgs>.Handler -= LevelEntered;
            base.Deactivate(player);
        }

        private void PrepareRippleRender(Camera2D camera, RenderStep step, GameTime gameTime)
        {
            Vector2 position = Game.Player.Instance.GameObject.Position - camera.TopLeftCorner;
            var effect = Shaders.Ripple;

            effect.Parameters["width"].SetValue(Magnitude);
            effect.Parameters["xcenter"].SetValue(position.X / 1320f);
            effect.Parameters["ycenter"].SetValue(position.Y / 720f);
            step.Effect = effect;
        }

        private void LevelEntered(LevelEnterEventArgs obj)
        {
            obj.RenderChain[LevelRenderStep.ExtraFrontToBack].Value.PreSteps.Add(PrepareRippleRender);
        }

        protected override void Activated(GameObj player)
        {
            ShoutProjectile.Fire(player);
            Effects.FusRoDahTextEffect.Display(player);

            Magnitude = 0;
            Tween.To(this, 1f, new Easing(Tween.EaseNone), "Magnitude", "3");
        }
    }
}
