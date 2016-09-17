using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.States
{
    public class StateDefinition
    {
        internal static readonly Dictionary<byte, StateDefinition> Lookup = new Dictionary<byte, StateDefinition>();

        protected byte _stateId;

        protected StateDefinition(byte stateId)
        {
            _stateId = stateId;

            Lookup[stateId] = this;
        }


        public virtual void Activate(Player player)
        {

        }

        public virtual void Deactivate(Player player)
        {

        }
    }
}
