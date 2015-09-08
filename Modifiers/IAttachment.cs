using RogueAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Modifiers
{
    public interface IAttachment
    {
        void Process(Entity owner);

        void Attach(Entity owner);

        void Detach(Entity owner);
    }
}
