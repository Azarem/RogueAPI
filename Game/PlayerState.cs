using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public enum PlayerState
    {
        Idle = 0,
        Walking = 1,
        Jumping = 2,
        Hurt = 3,
        Dashing = 4,
        LevelUp = 5,
        Blocking = 6,
        Flying = 7,
        Tanuki = 8,
        Dragon = 9
    }
}
