using DS2DEngine;
using RogueAPI.Game;
using RogueAPI.Projectiles;
using Tweener;

namespace RogueAPI.Spells
{
    public class TimeStop : SpellDefinition
    {
        public const byte Id = 4;
        public static readonly TimeStop Instance = new TimeStop();

        private TimeStop() : this(Id) { }

        protected TimeStop(byte id)
            : base(id)
        {
            displayName = "Time Stop";
            icon = "TimeStopIcon_Sprite";
            description = string.Format("[Input:{0}]  Toggles freezing all enemies on-screen. ", (int)Game.InputKeys.PlayerSpell1);
            soundList = new[] { "Cast_TimeStart" };

            //miscValue1 = 3f;
            //miscValue2 = 0f;

            rarity = 2;
            manaCost = 15;
            damageMultiplier = 0f;

            toggle = true;
            manaDrainAmount = 8f;
            manaDrainTime = 0.33f;
        }

        protected override bool OnCast(Entity source)
        {
            SoundManager.PauseMusic();
            //this.m_enemyPauseDuration = 0;
            //this.PauseAllEnemies();
            //Tween.To(m_traitAura, 0.2f, Tween.EaseNone, "ScaleX", "100", "ScaleY", "100");

            return true;
        }

        protected override void OnDeactivate(bool force)
        {

            SoundManager.PlaySound("Cast_TimeStop");
            SoundManager.ResumeMusic();

            base.OnDeactivate(force);

            //Tween.To(m_traitAura, 0.2f, Tween.EaseNone, "ScaleX", "0", "ScaleY", "0");
            //Tween.AddEndHandlerToLastTween(this, "UnpauseAllEnemies");
        }
    }
}
