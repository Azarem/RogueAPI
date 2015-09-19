using System;
using System.Linq;

namespace RogueAPI.Enemies
{
    public class Chicken : EnemyBase
    {
        public const byte Id = 26;
        public Chicken()
            : base(Id)
        {

        }

        public void MakeCollidable()
        {
            this.IsCollidable = true;
        }
    }
}
