using DS2DEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Effects
{
    public class EffectSpriteInstance : SpriteObj
    {
        public bool CanBeRotated = false;

        public EffectSpriteInstance(string spriteName) : base(spriteName)
        {

        }
    }
}
