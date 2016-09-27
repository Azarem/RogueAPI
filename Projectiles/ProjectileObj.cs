using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueAPI.Game;
using System;
using Tweener;

namespace RogueAPI.Projectiles
{
    public class ProjectileObj : PhysicsObj
    {
        public ProjectileObj(string spriteName) : base(spriteName) { }

        internal float m_elapsedLifeSpan;
        private Color m_blinkColour = Color.White;
        private float m_blinkTimer;

        public float AltX { get; set; }
        public float AltY { get; set; }
        public GameObj AttachedIcon { get; set; }
        public float BlinkTime { get; set; }
        public bool CanBeFusRohDahed { get; set; }
        public bool ChaseTarget { get; set; }
        public bool CollidesWith1Ways { get; set; }
        public bool CollidesWithTerrain { get; set; }
        public float LifeSpan;
        public GameObj Source { get; set; }
        public GameObj Target { get; set; }
        public bool DestroysWithTerrain { get; set; }
        public bool DestroysWithEnemy { get; set; }
        public bool FollowArc { get; set; }
        public bool DestroyOnRoomTransition { get; set; }
        public bool WrapProjectile { get; set; }
        public bool IgnoreInvincibleCounter { get; set; }
        public bool ShowIcon { get; set; }
        public int Damage { get; set; }
        public float RotationSpeed { get; set; }
        public bool IsDying { get; set; }
        public bool IsAlive { get; set; }
        public bool IgnoreBoundsCheck { get; set; }
        public bool GamePaused { get; set; }

        public Vector2 InitAngleRange;
        public Vector2 InitSpeedRange;
        public float InitAngleOffset;
        public Vector2 InitSourceAnchor;
        public bool InitLockPosition;

        public bool IsDemented
        {
            get
            {
                //EnemyObj source = this.Source as EnemyObj;
                //if (source != null && source.IsDemented)
                //{
                //    return true;
                //}
                return false;
            }
        }

        private int _spellId;
        public int Spell
        {
            get { return _spellId; }
            set
            {
                _spellId = value;
                _spellDefinition = Spells.SpellDefinition.GetById((byte)value);
            }
        }

        private Spells.SpellDefinition _spellDefinition;
        public Spells.SpellDefinition SpellDefinition
        {
            get { return _spellDefinition; }
            set
            {
                _spellDefinition = value;
                _spellId = value == null ? 0 : value.SpellId;
            }
        }

        public ProjectileDefinition Definition { get; set; }

        public CollisionType CollisionType { get { return (CollisionType)CollisionTypeTag; } set { CollisionTypeTag = (int)value; } }

        public void Reset()
        {
            m_elapsedLifeSpan = 0f;
            m_blinkColour = Color.White;
            m_blinkTimer = 0f;
            Source = null;
            CollidesWithTerrain = true;
            DestroysWithTerrain = true;
            DestroysWithEnemy = true;
            IsCollidable = true;
            IsWeighted = true;
            IsDying = false;
            IsAlive = true;
            Rotation = 0f;
            TextureColor = Color.White;
            Spell = 0;
            AltY = 0f;
            AltX = 0f;
            BlinkTime = 0f;
            IgnoreBoundsCheck = false;
            Scale = Vector2.One;
            DisableHitboxUpdating = false;
            AccelerationYEnabled = true;
            AccelerationXEnabled = true;
            GamePaused = false;
            DestroyOnRoomTransition = true;
            CanBeFusRohDahed = true;
            Flip = SpriteEffects.None;
            IgnoreInvincibleCounter = false;
            WrapProjectile = false;
            DisableCollisionBoxRotations = true;
            Tween.StopAllContaining(this, false);
        }

        public void Initialize(ProjectileDefinition definition, GameObj source, GameObj target)
        {
            Reset();

            Source = source;
            Target = target;
            Definition = definition;

            LifeSpan = definition.Lifespan;
            ChaseTarget = definition.ChaseTarget;
            UpdateHeading();
            TurnSpeed = definition.TurnSpeed;
            CollidesWithTerrain = definition.CollidesWithTerrain;
            //SpellDefinition = spellDefinition;
            DestroysWithTerrain = definition.DestroysWithTerrain;
            DestroysWithEnemy = definition.DestroysWithEnemy;
            FollowArc = definition.FollowArc;
            Orientation = MathHelper.ToRadians(definition.StartingRotation);
            ShowIcon = definition.ShowIcon;
            IsCollidable = definition.IsCollidable;
            CollidesWith1Ways = definition.CollidesWith1Ways;
            DestroyOnRoomTransition = definition.DestroyOnRoomTransition;
            CanBeFusRohDahed = definition.CanBeFusRohDahed;
            IgnoreInvincibleCounter = definition.IgnoreInvincibleCounter;
            WrapProjectile = definition.WrapProjectile;
            Damage = definition.Damage;
            IsWeighted = definition.IsWeighted;
            ChangeSprite(definition.SpriteName);
            RotationSpeed = definition.RotationSpeed;
            Scale = definition.Scale;
            AltX = definition.AltX;
            AltY = definition.AltY;
            InitAngleRange = definition.Angle;
            InitSpeedRange = definition.Speed;
            InitAngleOffset = definition.AngleOffset;
            InitSourceAnchor = definition.SourceAnchor;
            InitLockPosition = definition.LockPosition;
            Visible = true;
        }

        public void Prepare()
        {
            float rotation = 0f;

            if (Target == null)
            {
                rotation = (InitAngleRange.X != InitAngleRange.Y)
                    ? CDGMath.RandomFloat(InitAngleRange.X, InitAngleRange.Y)
                    : InitAngleRange.X;

                rotation += InitAngleOffset;

                if (Source.Flip != SpriteEffects.None)
                    if (Source.Rotation == 0f)
                        rotation = 180f - rotation;
                    else
                        rotation -= 180f;
            }
            else
            {
                var distanceX = Target.X - Source.X;
                var angleOffset = InitAngleOffset;

                if (Source.Flip == SpriteEffects.FlipHorizontally)
                {
                    distanceX += InitSourceAnchor.X;
                    angleOffset = -angleOffset;
                }

                rotation = MathHelper.ToDegrees((float)Math.Atan2(Target.Y - Source.Y - InitSourceAnchor.Y, distanceX)) + angleOffset;

                if (Source.Flip == SpriteEffects.FlipHorizontally && ChaseTarget)
                    Orientation = MathHelper.ToRadians(180f);
            }

            if (!InitLockPosition)
                Rotation = rotation;

            rotation = MathHelper.ToRadians(rotation);

            Core.AttachPhysicsObject(this);

            if (Source.Flip == SpriteEffects.None)
                X = Source.AbsX + InitSourceAnchor.X;
            else
                X = Source.AbsX - InitSourceAnchor.X;

            Y = Source.AbsY + InitSourceAnchor.Y;

            Vector2 vector2 = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            float speed = (InitSpeedRange.X != InitSpeedRange.Y)
                ? CDGMath.RandomFloat(InitSpeedRange.X, InitSpeedRange.Y)
                : InitSpeedRange.X;

            AccelerationX = vector2.X * speed;
            AccelerationY = vector2.Y * speed;
            CurrentSpeed = speed;

            if (Source.IsPlayer())
            {
                if (LifeSpan == 0f)
                    LifeSpan = 10f;

                CollisionType = CollisionType.Player;

                new ProjectileFireEvent(Source, Definition, this).Trigger();
            }
            else
            {
                if (LifeSpan == 0f)
                    LifeSpan = 15f;

                CollisionType = CollisionType.Enemy;
            }


            PlayAnimation(true);
        }


        public void UpdateHeading()
        {
            if (ChaseTarget && Target != null)
            {
                TurnToFace(Target.Position, TurnSpeed, 0.0166666675f);
                HeadingX = (float)Math.Cos(Orientation);
                HeadingY = (float)Math.Sin(Orientation);
            }
        }

        public void TurnToFace(Vector2 facePosition, float turnSpeed, float elapsedSeconds)
        {
            float angle = MathHelper.WrapAngle((float)Math.Atan2(facePosition.Y - Position.Y, facePosition.X - Position.X) - Orientation);
            float limit = turnSpeed * 60f * elapsedSeconds;
            angle = MathHelper.Clamp(angle, -limit, limit);
            Orientation = MathHelper.WrapAngle(Orientation + angle);
        }

        public void Blink(Color blinkColour, float duration)
        {
            m_blinkColour = blinkColour;
            m_blinkTimer = duration;
        }

        public void Update(GameTime gameTime)
        {
            if (IsPaused)
                return;

            if (Definition != null)
                Definition.Update(this, gameTime);

            float totalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ChaseTarget && Target != null)
            {
                TurnToFace(Target.Position, TurnSpeed, totalSeconds);
                HeadingX = (float)Math.Cos(Orientation);
                HeadingY = (float)Math.Sin(Orientation);
                AccelerationX = 0f;
                AccelerationY = 0f;
                Position += (Heading * (CurrentSpeed * totalSeconds));
                Rotation = MathHelper.ToDegrees(Orientation);
            }

            if (FollowArc && !ChaseTarget && !IsDying)
                Rotation = MathHelper.ToDegrees((float)Math.Atan2(AccelerationY, AccelerationX));
            else if (!ChaseTarget)
                Rotation += RotationSpeed * 60f * totalSeconds;

            m_elapsedLifeSpan += totalSeconds;

            if (m_elapsedLifeSpan >= LifeSpan)
                IsAlive = false;

            if (m_blinkTimer > 0f)
            {
                m_blinkTimer -= totalSeconds;
                TextureColor = m_blinkColour;
            }
            else if (TextureColor == m_blinkColour)
                TextureColor = Color.White;
        }

        public void KillProjectile()
        {
            IsAlive = false;
            IsDying = false;
        }

        public bool OnCollision(PhysicsObjContainer target, bool targetIsPlayer, Vector2 knockbackAmount)
        {
            if (Definition != null)
                return Definition.OnCollision(this, target, targetIsPlayer, knockbackAmount);
            return true;
        }

        //public override void CollisionResponse(CollisionBox thisBox, CollisionBox otherBox, int collisionResponseType)
        //{
        //    base.CollisionResponse(thisBox, otherBox, collisionResponseType);
        //}

        public void RunDestroyAnimation(bool hitPlayer)
        {
            if (!IsDying && !IsDemented)
            {
                CurrentSpeed = 0f;
                AccelerationX = 0f;
                AccelerationY = 0f;
                IsDying = true;

                if (Definition != null)
                    Definition.OnDestroy(this, hitPlayer);


                //string spriteName = base.SpriteName;
                //string str = spriteName;
                //if (spriteName != null)
                //{
                //switch (SpriteName)
                //{
                //    case "ArrowProjectile_Sprite":
                //    case "SpellClose_Sprite":
                //    case "SpellDagger_Sprite":
                //        if (!hitPlayer)
                //        {
                //            IsWeighted = false;
                //            IsCollidable = false;
                //            Tween.To(this, 0.3f, Linear.EaseNone, "delay", "0.3", "Opacity", "0");
                //            Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        }
                //        else
                //        {
                //            Tween.By(this, 0.3f, Linear.EaseNone, "Rotation", "270");
                //            Tween.By(this, 0.3f, Linear.EaseNone, "X", CDGMath.RandomInt(-50, 50).ToString(), "Y", CDGMath.RandomInt(-100, -50).ToString());
                //            Tween.To(this, 0.3f, Linear.EaseNone, "Opacity", "0");
                //            Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        }
                //        break;

                //    case "ShurikenProjectile1_Sprite":
                //    case "BoneProjectile_Sprite":
                //    case "SpellBounce_Sprite":
                //    case "LastBossSwordVerticalProjectile_Sprite":
                //        Tween.StopAllContaining(this, false);
                //        IsCollidable = false;
                //        Tween.By(this, 0.3f, Linear.EaseNone, "X", CDGMath.RandomInt(-50, 50).ToString(), "Y", CDGMath.RandomInt(-100, 100).ToString());
                //        Tween.To(this, 0.3f, Linear.EaseNone, "Opacity", "0");
                //        Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        break;

                //    case "HomingProjectile_Sprite":
                //        ProceduralLevelScreen currentScreen = Game.ScreenManager.CurrentScreen as ProceduralLevelScreen;
                //        if (currentScreen != null)
                //            currentScreen.ImpactEffectPool.DisplayExplosionEffect(Position);

                //        SoundManager.Play3DSound(this, Game.ScreenManager.Player, "MissileExplosion_01", "MissileExplosion_02");
                //        KillProjectile();
                //        break;

                //    case "SpellAxe_Sprite":
                //    case "SpellDualBlades_Sprite":
                //        IsCollidable = false;
                //        AccelerationX = 0f;
                //        AccelerationY = 0f;
                //        Tween.To(this, 0.3f, Tween.EaseNone, "Opacity", "0");
                //        Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        break;

                //    case "SpellDamageShield_Sprite":
                //    case "SpellDisplacer_Sprite":
                //        Tween.To(this, 0.2f, Tween.EaseNone, "Opacity", "0");
                //        Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        break;

                //    case "LastBossSwordProjectile_Sprite":
                //        IsCollidable = false;
                //        Tween.StopAllContaining(this, false);
                //        Tween.By(this, 0.3f, Linear.EaseNone, "Rotation", "270");
                //        Tween.By(this, 0.3f, Linear.EaseNone, "Y", CDGMath.RandomInt(-100, -50).ToString());
                //        Tween.To(this, 0.3f, Linear.EaseNone, "Opacity", "0");
                //        Tween.AddEndHandlerToLastTween(this, "KillProjectile");
                //        break;

                //case "SpellNuke_Sprite":
                //    ProceduralLevelScreen proceduralLevelScreen = Game.ScreenManager.CurrentScreen as ProceduralLevelScreen;
                //    if (proceduralLevelScreen != null)
                //        proceduralLevelScreen.ImpactEffectPool.CrowDestructionEffect(Position);
                //    KillProjectile();
                //    break;

                //    case "EnemyFlailKnightBall_Sprite":
                //    case "WizardIceSpell_Sprite":
                //    case "WizardEarthSpell_Sprite":
                //    case "SpellTimeBomb_Sprite":
                //    case "SpellLaser_Sprite":
                //    case "SpellBoomerang_Sprite":
                //        KillProjectile();
                //        break;

                //    default:
                //        if (SpriteName == "WizardIceProjectile_Sprite")
                //            SoundManager.Play3DSound(this, Game.ScreenManager.Player, "Ice_Wizard_Break_01", "Ice_Wizard_Break_02", "Ice_Wizard_Break_03");

                //        string newSprite = SpriteName.Replace("_", "Explosion_");
                //        ChangeSprite(newSprite);
                //        AnimationDelay = 0.0333333351f;
                //        PlayAnimation(false);
                //        IsWeighted = false;
                //        IsCollidable = false;

                //        if (newSprite != "EnemySpearKnightWaveExplosion_Sprite" && newSprite != "WizardIceProjectileExplosion_Sprite")
                //            Rotation = 0f;

                //        Tween.RunFunction(0.5f, this, "KillProjectile");
                //        break;
                //}
                //}

            }
        }

    }
}
