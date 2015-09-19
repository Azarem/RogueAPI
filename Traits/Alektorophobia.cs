using System;
using System.Linq;
using DS2DEngine;
using Tweener;
using Microsoft.Xna.Framework;

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

        protected internal override void Activate()
        {
            base.Activate();
            Game.RandomItemDrop.ItemDropped += RandomItemDrop_ItemDropped;
        }

        protected internal override void Deactivate()
        {
            Game.RandomItemDrop.ItemDropped -= RandomItemDrop_ItemDropped;
            base.Deactivate();
        }

        void RandomItemDrop_ItemDropped(PipeEventState<PhysicsObjContainer, Game.RandomItemDrop> args)
        {
            if(!args.Handled && args.Target != null && args.Target.DropType == 2)
            {
                var chicken = Core.CreateEnemy(Enemies.Chicken.Id, Enemies.EnemyDifficulty.Basic);
                chicken.AccelerationX = -500f;
                chicken.Position = args.Sender.Position - new Vector2(0, -50f);
                chicken.IsCollidable = false;

                Core.AttachEnemyToCurrentRoom(chicken);

                Tween.RunFunction(0.2f, chicken, "MakeCollideable");
                SoundManager.Play3DSound(args.Sender, Game.Player.Instance, "Chicken_Cluck_01", "Chicken_Cluck_02", "Chicken_Cluck_03");

                //            EnemyObj_Chicken enemyObjChicken = new EnemyObj_Chicken(null, null, null, GameTypes.EnemyDifficulty.BASIC)
                //            {
                //                AccelerationY = -500f,
                //                Position = base.Position
                //            };
                //            EnemyObj_Chicken y = enemyObjChicken;
                //            y.Y = y.Y - 50f;
                //            enemyObjChicken.SaveToFile = false;
                //            player.AttachedLevel.AddEnemyToCurrentRoom(enemyObjChicken);
                //            enemyObjChicken.IsCollidable = false;
                //            Tween.RunFunction(0.2f, enemyObjChicken, "MakeCollideable", new object[0]);
                //            PlayerObj playerObj1 = Game.ScreenManager.Player;
                //            string[] strArrays3 = new string[] { "Chicken_Cluck_01", "Chicken_Cluck_02", "Chicken_Cluck_03" };
                //            SoundManager.Play3DSound(this, playerObj1, strArrays3);
                args.Handled = true;
            }
        }

        //BreakableObj.Break - Spawn chicken enemy when breakable item is dropped
    }
}
