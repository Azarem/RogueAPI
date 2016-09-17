using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public enum CollisionType
    {
        Null = 0,
        Wall = 1,
        Player = 2,
        Enemy = 3,
        EnemyWall = 4,
        WallForPlayer = 5,
        WallForEnemy = 6,
        PlayerTrigger = 7,
        EnemyTrigger = 8,
        GlobalTrigger = 9,
        GlobalDamageWall = 10
    }
}
