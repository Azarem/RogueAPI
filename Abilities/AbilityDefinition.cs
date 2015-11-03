using DS2DEngine;
using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Abilities
{
    public abstract class AbilityDefinition
    {
        public int ManaCost { get; set; }
        public int DeactivateCost { get; set; }
        public bool IsCastable { get; set; }
        public bool IsSwitchable { get; set; }
        public bool IsActive { get; set; }

        protected internal virtual void Activate(Player player)
        {
            Event<KeyPressEventArgs>.Handler += KeyPressed;
        }

        protected internal virtual void Deactivate(Player player)
        {
            Event<KeyPressEventArgs>.Handler -= KeyPressed;
        }

        internal protected void BeginActivate(GameObj player)
        {
        }

        protected virtual void Activated(GameObj player) { }

        private void KeyPressed(KeyPressEventArgs obj)
        {
            if (obj.Key == Game.InputKeys.PlayerBlock)
            {
                if (IsCastable)
                {
                    
                }
            }
        }

    }
}
