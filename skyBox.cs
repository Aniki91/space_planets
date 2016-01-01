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
    public class skyBox
    {
        public Model Space;
        public TextureCube skyBoxTexture;
        public Effect skyBoxEffect;
        public float size = 10f;

        public skyBox()
        {
            Space = spaceGame.Instance.Content.Load<Model>("skyBoxModel");
            skyBoxTexture = spaceGame.Instance.Content.Load<TextureCube>("Space");
            skyBoxEffect = spaceGame.Instance.Content.Load<Effect>("skyBoxEffect");
        }

        public void Draw(Matrix view, Matrix projection, Vector3 cameraPosition)
        {
            foreach (EffectPass pass in skyBoxEffect.CurrentTechnique.Passes)
            {
                foreach (ModelMesh mesh in Space.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = skyBoxEffect;
                        part.Effect.Parameters["World"].SetValue(
                            Matrix.CreateScale(size) * Matrix.CreateTranslation(cameraPosition));
                        part.Effect.Parameters["View"].SetValue(view);
                        part.Effect.Parameters["Projection"].SetValue(projection);
                        part.Effect.Parameters["SkyBoxTexture"].SetValue(skyBoxTexture);
                        part.Effect.Parameters["CameraPosition"].SetValue(cameraPosition);
                    }

                    mesh.Draw();
                }
            }
        }
    }
}
