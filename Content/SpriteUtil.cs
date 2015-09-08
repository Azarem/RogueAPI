using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpriteSystem;

namespace RogueAPI.Content
{
    public static class SpriteUtil
    {
        private static readonly FieldInfo textureDictField = typeof(SpriteSystem.SpriteLibrary).GetField("_textureDict", BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly FieldInfo spriteDictField = typeof(SpriteSystem.SpriteLibrary).GetField("_spriteDict", BindingFlags.NonPublic | BindingFlags.Static);
        private static Dictionary<string, Texture2D> textureDict;
        private static Dictionary<string, SpritesheetObj> spriteDict;

        public static GraphicsDeviceManager GraphicsDeviceManager;

        internal static Dictionary<string, Texture2D> TextureDictionary { get { return textureDict ?? (textureDict = textureDictField.GetValue(null) as Dictionary<string, Texture2D>); } }
        internal static Dictionary<string, SpritesheetObj> SpriteDictionary { get { return spriteDict ?? (spriteDict = spriteDictField.GetValue(null) as Dictionary<string, SpritesheetObj>); } }

        public static void LoadTexture(string textureName, string filePath)
        {
            Texture2D tex;
            using (var stream = File.OpenRead(filePath))
                TextureDictionary[textureName] = tex = Texture2D.FromStream(GraphicsDeviceManager.GraphicsDevice, stream);

            var spriteObj = new SpritesheetObj(textureName, filePath);
            spriteObj.AddImageData(0, 0, 0, tex.Bounds.Center.X, tex.Bounds.Center.Y, tex.Width, tex.Height);
            SpriteDictionary[textureName] = spriteObj;
        }

    }
}
