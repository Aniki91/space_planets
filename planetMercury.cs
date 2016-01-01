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
    public class planetMercury : planetActor
    {
        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            cameraPos = new Vector3(10, 0, 0);
            cameraLook = new Vector3(0, 0, 0);

            planetPos = new Vector3(0, 0, 0);
            planetRot = 0.0f;

            aspectRatio = spaceGame.Instance.GraphicsDevice.Viewport.AspectRatio;

            planet = spaceGame.Instance.Content.Load<Model>("planetModel_Mercury");
            (planet.Meshes[0].Effects[0] as BasicEffect).EnableDefaultLighting();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            planetRot = planetRot + 0.001f;

            if (keyState.IsKeyDown(Keys.A))
            {
                //cameraPos.X = cameraPos.X + 0.25f;
            }

            if (keyState.IsKeyDown(Keys.D))
            {
                //cameraPos.X = cameraPos.X - 0.25f;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                cameraPos.Y = cameraPos.Y + 0.25f;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                cameraPos.Y = cameraPos.Y - 0.25f;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                //cameraLook.X = cameraLook.X + 0.25f;
                planetRot = planetRot + 0.01f;
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                //cameraLook.X = cameraLook.X - 0.25f;
                planetRot = planetRot - 0.01f;
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                //cameraLook.Y = cameraLook.Y + 0.25f;
                cameraPos.X = cameraPos.X - 0.25f;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                //cameraLook.Y = cameraLook.Y - 0.25f;
                cameraPos.X = cameraPos.X + 0.25f;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            /*planet.Draw(Matrix.Identity,
                Matrix.CreateLookAt(cameraPos, cameraLook, Vector3.Up),
                Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, spaceGame.Instance.GraphicsDevice.Viewport.AspectRatio, 1.0f, 90.0f)); //MathHelper.PiOver4*/

            Matrix[] transforms = new Matrix[planet.Bones.Count];
            planet.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in planet.Meshes)
            {

                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(planetRot) * Matrix.CreateTranslation(planetPos);
                    effect.View = Matrix.CreateLookAt(cameraPos, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1.0f, 10000.0f);
                }

                mesh.Draw();
            }
        }
    }
}