using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Modifiers
{
    public abstract class AttachmentCollectionBase : IAttachment, IAttachmentCollection
    {

        public abstract IEnumerator<IAttachment> GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        public abstract void Process(Game.Entity owner);
        public abstract void Attach(Game.Entity owner);
        public abstract void Detach(Game.Entity owner);
    }
}
