using DS2DEngine;
using System;
using System.Linq;

namespace RogueAPI.Enemies
{
    public class Chicken : EnemyBase
    {
        public const byte Id = 26;

        public Chicken(PhysicsObjContainer gameObject)
            : base(Id, gameObject)
        {

        }

        public void MakeCollidable()
        {
            this.GameObject.IsCollidable = true;
        }
    }
}
