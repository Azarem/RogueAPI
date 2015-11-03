using System;
using System.Linq;
using DS2DEngine;
using RogueAPI.Modifiers;
using RogueAPI.Stats;
using System.Collections.Generic;

namespace RogueAPI.Game
{
    public class Entity
    {
        private PhysicsObjContainer _gameObject;
        public PhysicsObjContainer GameObject { get { return _gameObject; } }

        public Entity(PhysicsObjContainer gameObject)
        {
            _gameObject = gameObject;
        }

        protected StatDefinition[] _statArray = new StatDefinition[16];
        
        public StatDefinition GetStatObject(byte statId)
        {
            StatDefinition def = null;

            var len = _statArray.Length;
            if (statId >= len)
            {
                while (statId >= len)
                    len <<= 1;

                var newArr = new StatDefinition[len];
                _statArray.CopyTo(newArr, 0);
                _statArray = newArr;
            }
            else
                def = _statArray[statId];

            if (def == null)
                _statArray[statId] = (StatDefinition)Activator.CreateInstance(StatDefinition.All[statId]);

            return def;
        }
        
    }
}
