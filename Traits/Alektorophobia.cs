using System;
using System.Linq;
using DS2DEngine;
using Tweener;
using Microsoft.Xna.Framework;
using RogueAPI.Game;

namespace RogueAPI.Traits
{
    public class Alektorophobia : TraitDefinition
    {
        public const byte Id = 24;
        public static readonly Alektorophobia Instance = new Alektorophobia();

        protected Alektorophobia()
            : base(Id)
        {
            this.DisplayName = "Alektorophobia";
            this.Description = "Chickens freak you out.";
            this.ProfileCardDescription = "You are scared of chickens.";
            this.Rarity = 2;
        }

        protected internal override void Activate(Player player)
        {
            base.Activate(player);
            RandomItemDrop.ItemDropped += RandomItemDrop_ItemDropped;
        }

        protected internal override void Deactivate(Player player)
        {
            RandomItemDrop.ItemDropped -= RandomItemDrop_ItemDropped;
            base.Deactivate(player);
        }

        void RandomItemDrop_ItemDropped(PipeEventState<PhysicsObjContainer, Game.RandomItemDrop> args)
        {
            if (!args.Handled && args.Target != null && args.Target.DropType == 2)
            {
                var chicken = Core.CreateEnemy(Enemies.Chicken.Id, Enemies.EnemyDifficulty.Basic);
                chicken.AccelerationX = -500f;
                chicken.Position = args.Sender.Position - new Vector2(0, -50f);
                chicken.IsCollidable = false;

                Core.AttachEnemyToCurrentRoom(chicken);

                Tween.RunFunction(0.2f, chicken, "MakeCollideable");
                SoundManager.Play3DSound(args.Sender, Game.Player.Instance.GameObject, "Chicken_Cluck_01", "Chicken_Cluck_02", "Chicken_Cluck_03");

                args.Handled = true;
            }
        }

    }
}
