using System;
using System.Collections.Generic;
using System.Linq;
using DS2DEngine;

namespace RogueAPI.Game
{
    public class RandomItemDrop
    {
        public int DropChance;
        public int DropType;
        public float Amount;

        public static List<RandomItemDrop> List = new List<RandomItemDrop>() { 
            new RandomItemDrop(){ DropChance = 3, DropType = 2, Amount = 0.1f },
            new RandomItemDrop(){ DropChance = 4, DropType = 3, Amount = 0.1f },
            new RandomItemDrop(){ DropChance = 36, DropType = 1, Amount = 10f },
            new RandomItemDrop(){ DropChance = 1, DropType = 10, Amount = 100f }
        };

        public static RandomItemDrop GetRandomDrop()
        {
            int rand = CDGMath.RandomInt(1, 100);
            int chance = 0;
            foreach (var d in List)
            {
                chance += d.DropChance;
                if (rand <= chance)
                    return d;
            }
            return null;
        }

        public static PipeEventState<PhysicsObjContainer, RandomItemDrop> PipeRandomDrop(PhysicsObjContainer source)
        {
            var args = new PipeEventState<PhysicsObjContainer, RandomItemDrop>(source, GetRandomDrop());

            if (args.Target != null && ItemDropped != null)
                ItemDropped(args);

            return args;
        }

        public static event PipeEventHandler<PhysicsObjContainer, RandomItemDrop> ItemDropped;

        //public static PipeEventState<object, RandomItemDrop> OnItemDropped(object source, RandomItemDrop drop)
        //{
        //    var args = new PipeEventState<object, RandomItemDrop>(source, drop);

        //    if (ItemDropped != null)
        //        ItemDropped(args);

        //    return args;
        //}
    }
}
