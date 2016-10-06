using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueAPI.Effects
{
    public class LoadingGateSmokeEffect : DustEffect
    {
        new public static readonly LoadingGateSmokeEffect Instance = new LoadingGateSmokeEffect();

        public override float Rotation { get { return 0; } }

        protected LoadingGateSmokeEffect()
        {
            _scale = new Vector2(1.5f);
        }

        public static void Display(int numEntities)
        {
            float step = 1320f / numEntities;
            lock (_defaultCommands)
                for (int i = 0; i < numEntities; i++)
                    Instance.Run(new Vector2(step * i, 720f), x =>
                    {
                        x.Sprite.ForceDraw = true;

                        var cmd = _defaultCommands[0];
                        cmd.Properties[1] = "0.8";

                        cmd = _defaultCommands[1];
                        cmd.Properties[1] = CDGMath.RandomFloat(-180f, 180f).ToString();

                        cmd = _defaultCommands[2];
                        cmd.Properties[1] = CDGMath.RandomInt(-50, 50).ToString();
                        cmd.Properties[3] = CDGMath.RandomInt(-50, 0).ToString();

                        cmd = _defaultCommands[3];
                        cmd.Duration = 0.5f;
                        cmd.InitialValues[0] = 0.8f;
                    });
        }
    }
}
