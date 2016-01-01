using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spaceFlight
{
    public abstract class planetActor
    {
        //
        //public Texture2D planetSprite;
        //public Vector2 planetPos;
        //public Vector2 sunCent;
        //public float planetRot;
        //
        public Model planet;
        public Vector3 cameraPos;
        public Vector3 cameraLook;
        public Vector3 planetPos;
        public float planetRot;
        public float aspectRatio;

        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}
