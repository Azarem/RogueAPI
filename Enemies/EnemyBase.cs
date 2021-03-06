﻿using DS2DEngine;
using System;
using System.Linq;

namespace RogueAPI.Enemies
{
    public class EnemyBase : Game.Entity
    {
        public readonly byte EnemyId;

        protected EnemyBase(byte id, PhysicsObjContainer gameObject)
            : base(gameObject)
        {
            EnemyId = id;
        }
    }
}
