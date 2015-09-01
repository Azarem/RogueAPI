using RogueAPI.Classes;
using RogueAPI.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public static class Player
    {
        private static PlayerStatus status = new PlayerStatus();
        private static ClassDefinition _class;
        private static List<Rune> runes = new List<Rune>();

        public static PlayerStatus Status { get { return status; } }
        public static List<Rune> Runes { get { return runes; } }
        public static ClassDefinition Class { get { return _class; } set { _class = value; } }
    }
}
