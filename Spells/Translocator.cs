using DS2DEngine;
using Microsoft.Xna.Framework;
using RogueAPI.Game;
using Tweener;
using Tweener.Ease;

namespace RogueAPI.Spells
{
    public class Translocator : SpellDefinition
    {
        public const byte Id = 6;
        public static readonly Translocator Instance = new Translocator();

        protected ObjContainer _shadowSprite;

        private Translocator() : this(Id) { }

        protected Translocator(byte id)
            : base(id)
        {
            displayName = "Quantum Translocator";
            icon = "TranslocatorIcon_Sprite";
            description = string.Format("[Input:{0}]  Drops and teleports to your shadow.", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "mfqt_teleport_out" };

            rarity = 3;
            manaCost = 5;
            damageMultiplier = 0f;
            toggle = true;
        }

        public override void Attach(Player player)
        {
            base.Attach(player);
            Event<PlayerDrawEventArgs>.Handler += PlayerDrawHandler;
        }

        public override void Detach(Player player)
        {
            Event<PlayerDrawEventArgs>.Handler -= PlayerDrawHandler;
            base.Detach(player);

            if (_shadowSprite != null)
            {
                _shadowSprite.Dispose();
                _shadowSprite = null;
            }
        }

        private void PlayerDrawHandler(PlayerDrawEventArgs args)
        {
            if (args.IsPreDraw && _shadowSprite != null && _shadowSprite.Visible)
                _shadowSprite.Draw(args.Camera);
        }


        protected override bool OnCast(Entity source)
        {
            var obj = source.GameObject;

            if (_shadowSprite == null)
                _shadowSprite = new ObjContainer(obj.SpriteName)
                {
                    OutlineColour = Color.Blue,
                    OutlineWidth = 2,
                    TextureColor = Color.Black
                };
            else
                _shadowSprite.ChangeSprite(obj.SpriteName);

            _shadowSprite.Position = obj.Position;
            _shadowSprite.Flip = obj.Flip;
            _shadowSprite.Scale = Vector2.Zero;
            _shadowSprite.Visible = true;

            _shadowSprite.GoToFrame(obj.CurrentFrame);

            for (var i = 0; i < obj.NumChildren; i++)
            {
                var src = obj.GetChildAt(i) as SpriteObj;
                var dst = _shadowSprite.GetChildAt(i) as SpriteObj;
                var show = src.Visible;

                if (source is Player && (
                        i == 16 || (
                        Player.Class is Classes.SpellSword && (i == 10 || i == 11)
                    )))
                    show = false;

                dst.ChangeSprite(src.SpriteName);
                dst.Visible = show;
            }

            Tween.To(_shadowSprite, 0.4f, Linear.EaseNone, "ScaleX", obj.ScaleX.ToString(), "ScaleY", obj.ScaleY.ToString());

            Effects.InverseEmitEffect.Display(_shadowSprite.Position);

            return true;
        }

        protected override void OnDeactivate(bool force)
        {
            if (!force)
            {
                var player = Player.Instance.GameObject;
                var scale = player.Scale;
                player.DisableAllWeight = true;
                Tween.To(player, 0.08f, Linear.EaseNone, "ScaleX", "3", "ScaleY", "0");
                Tween.To(player, 0f, Linear.EaseNone, "delay", "0.1", "X", _shadowSprite.Position.X.ToString(), "Y", _shadowSprite.Position.Y.ToString());
                Tween.AddEndHandlerToLastTween(this, "ResetState", player, scale);
                //Update Camera

                SoundManager.PlaySound("mfqt_teleport_in");
            }

            _shadowSprite.Visible = false;

            base.OnDeactivate(force);
        }

        protected virtual void ResetState(PhysicsObjContainer player, Vector2 scale)
        {
            player.DisableAllWeight = false;
            player.Scale = scale;
        }
    }
}
