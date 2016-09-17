using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    [Flags]
    public enum InputFlags
    {
        None = 0,
        MenuConfirm1 = 0x1,
        MenuConfirm2 = 0x2,
        MenuCancel1 = 0x4,
        MenuCancel2 = 0x8,
        MenuOptions = 0x10,
        MenuRogueMode = 0x20,
        MenuCredits = 0x40,
        MenuProfileCard = 0x80,
        MenuPause = 0x100,
        MenuMap = 0x200,
        PlayerJump1 = 0x400,
        PlayerJump2 = 0x800,
        PlayerAttack = 0x1000,
        PlayerBlock = 0x2000,
        PlayerDashLeft = 0x4000,
        PlayerDashRight = 0x8000,
        PlayerUp1 = 0x10000,
        PlayerUp2 = 0x20000,
        PlayerDown1 = 0x40000,
        PlayerDown2 = 0x80000,
        PlayerLeft1 = 0x100000,
        PlayerLeft2 = 0x200000,
        PlayerRight1 = 0x400000,
        PlayerRight2 = 0x800000,
        PlayerSpell1 = 0x1000000,
        MenuProfileSelect = 0x2000000,
        MenuDeleteProfile = 0x4000000
    }
}
