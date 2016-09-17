using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.States
{
    public class IdleState : StateDefinition
    {
        public static readonly IdleState Instance = new IdleState();

        protected IdleState() : base(0)
        {

        }
    }
}
