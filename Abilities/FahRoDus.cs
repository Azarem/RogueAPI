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
            var effect = Effects.RippleEffect;

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
            var proj = Projectile.Fire(player);

            proj.Opacity = 0f;
            proj.CollisionTypeTag = 2;
            proj.Spell = 20;
            proj.IgnoreBoundsCheck = true;
            Tween.To(proj, 0.2f, new Easing(Tween.EaseNone), "ScaleX", "100", "ScaleY", "50");
            Tween.AddEndHandlerToLastTween(proj, "KillProjectile");
            SoundManager.PlaySound("Cast_FasRoDus");

            Core.AttachEffect(EffectType.FahRoDus, null, new Vector2(player.X, player.Bounds.Top));

            Magnitude = 0;
            Tween.To(this, 1f, new Easing(Tween.EaseNone), "Magnitude", "3");
        }
    }
}
