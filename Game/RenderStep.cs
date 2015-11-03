using DS2DEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueAPI.Game
{
    public class RenderStep
    {
        public bool Skip;
        public RenderTarget2D RenderTarget;
        public SpriteSortMode SpriteSortMode;
        public BlendState BlendState;
        public SamplerState SamplerState;
        public DepthStencilState DepthStencilState;
        public RasterizerState RasterizerState;
        public Effect Effect;
        public Matrix TransformMatrix;
        public Color? ClearColor;
        public List<ShaderStep> ShaderSteps;
        public List<Action<Camera2D, RenderStep, GameTime>> PreSteps;
        public List<Action<Camera2D, RenderStep, GameTime>> DrawSteps;

        public RenderStep(RenderTarget2D renderTarget, SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null, Color? clearColor = null, ShaderStep[] shaderSteps = null, Action<Camera2D, RenderStep, GameTime>[] preSteps = null, Action<Camera2D, RenderStep, GameTime>[] drawSteps = null)
        {
            RenderTarget = renderTarget;
            SpriteSortMode = sortMode;
            BlendState = blendState ?? BlendState.AlphaBlend;
            SamplerState = samplerState ?? SamplerState.LinearClamp;
            DepthStencilState = depthStencilState;
            RasterizerState = rasterizerState;
            Effect = effect;
            TransformMatrix = transformMatrix ?? Matrix.Identity;
            ClearColor = clearColor;
            ShaderSteps = new List<ShaderStep>(shaderSteps ?? new ShaderStep[0]);
            PreSteps = new List<Action<Camera2D, RenderStep, GameTime>>(preSteps ?? new Action<Camera2D, RenderStep, GameTime>[0]);
            DrawSteps = new List<Action<Camera2D, RenderStep, GameTime>>(drawSteps ?? new Action<Camera2D, RenderStep, GameTime>[0]);
        }

        public void Draw(Camera2D camera, GameTime gameTime)
        {
            if (PreSteps.Count > 0)
                foreach (var s in PreSteps)
                    s(camera, this, gameTime);

            if (Skip)
                return;

            camera.GraphicsDevice.SetRenderTarget(RenderTarget);

            if (ClearColor != null)
                camera.GraphicsDevice.Clear(ClearColor.Value);
            
            if (ShaderSteps.Count > 0)
                foreach (var s in ShaderSteps)
                    s.Prepare(camera);

            camera.Begin(SpriteSortMode, BlendState, SamplerState, DepthStencilState, RasterizerState, Effect, TransformMatrix);

            if (DrawSteps.Count > 0)
                foreach (var s in DrawSteps)
                    s(camera, this, gameTime);

            camera.End();
        }
    }

    public class ShaderStep
    {
        public int Index;
        public Texture Texture;
        public SamplerState SamplerState;

        public ShaderStep(int index, Texture texture = null, SamplerState samplerState = null)
        {
            Index = index;
            Texture = texture;
            SamplerState = samplerState;
        }

        public void Prepare(Camera2D camera)
        {
            if (Texture != null)
                camera.GraphicsDevice.Textures[Index] = Texture;
            if (SamplerState != null)
                camera.GraphicsDevice.SamplerStates[Index] = SamplerState;
        }
    }
}
