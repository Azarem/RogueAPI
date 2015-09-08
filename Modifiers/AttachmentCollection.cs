using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Modifiers
{
    public class AttachmentCollection<TAttachment> : AttachmentCollectionBase
        //where TSlot : Enum
        where TAttachment : class, IAttachment
    {
        protected readonly Entity owner;
        protected readonly TAttachment[] list;

        public AttachmentCollection(Entity owner)
        {
            //var max = typeof(TSlot).GetEnumValues().Cast<int>().Max();
            //list = new TAttachment[max];

            //this.owner = owner;
        }

        public TAttachment this[int slot]
        {
            get { return list[slot]; }
            set
            {
                var current = list[slot];
                if (current != null)
                    current.Detach(owner);
                list[slot] = value;
                if (value != null)
                    value.Attach(owner);
            }
        }

        public override IEnumerator<IAttachment> GetEnumerator()
        {
            return list.Where(x => x != null).GetEnumerator();
        }

        

        public override void Process(Entity owner)
        {
            foreach (var a in this)
                a.Process(owner);
        }

        public override void Attach(Entity owner)
        {
        }

        public override void Detach(Entity owner)
        {
        }
    }
}
