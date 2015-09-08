using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Modifiers
{
    public abstract class AttachmentBase : IAttachment
    {
        public readonly ModifierBase[] Modifiers;


        public void Process(Entity owner)
        {
            throw new NotImplementedException();
        }

        public void Attach(Entity owner)
        {
            throw new NotImplementedException();
        }

        public void Detach(Entity owner)
        {
            throw new NotImplementedException();
        }
    }
}
