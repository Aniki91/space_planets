using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace spaceFlight
{
    public class spaceGame : Microsoft.Xna.Framework.Game
    {
        private static spaceGame instance;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private static readonly TimeSpan timeBetweenInput = TimeSpan.FromMilliseconds(250);
        private TimeSpan lastInput;

        public skyBox Space;
        public int planetChoice;

        Matrix world = Matrix.Identity;
        Matrix view = Matrix.CreateLookAt(new Vector3(20, 0, 0), new Vector3(0, 0, 0), Vector3.UnitY);
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 600f, 0.1f, 100f);
        Vector3 cameraPosition;
        float distance = 20;

        public planetActor Sun;
        public planetActor Mercury;
        public planetActor Venus;
        public planetActor Earth;
        public planetActor Mars;
        public planetActor Jupiter;
        public planetActor Saturn;
        public planetActor Uranus;
        public planetActor Neptune;
        public planetActor Pluto;

        public static spaceGame Instance
        {
            get
            {
                return instance;
            }
        }

        public spaceGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            instance = this;
        }

        protected override void Initialize()
        {
            Sun = new starSun();
            Mercury = new planetMercury();
            Venus = new planetVenus();
            Earth = new planetEarth();
            Mars = new planetMars();
            Jupiter = new planetJupiter();
            Saturn = new planetSaturn();
            Uranus = new planetUranus();
            Neptune = new planetNeptune();
            Pluto = new planetPluto();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            planetChoice = 4;

            Space = new skyBox();

            Sun.LoadContent();
            Mercury.LoadContent();
            Venus.LoadContent();
            Earth.LoadContent();
            Mars.LoadContent();
            Jupiter.LoadContent();
            Saturn.LoadContent();
            Uranus.LoadContent();
            Neptune.LoadContent();
            Pluto.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            cameraPosition = distance * new Vector3((float)Math.Sin(10), 0, (float)Math.Cos(10));
            view = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);

            if (keyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (planetChoice <= 0)
            {
                planetChoice = 1;
            }

            if (planetChoice >= 11)
            {
                planetChoice = 10;
            }

            if (keyState.IsKeyDown(Keys.PageUp) && lastInput + timeBetweenInput < gameTime.TotalGameTime)
            {
                planetChoice = planetChoice + 1;

                lastInput = gameTime.TotalGameTime;
            }

            if (keyState.IsKeyDown(Keys.PageDown) && lastInput + timeBetweenInput < gameTime.TotalGameTime)
            {
                planetChoice = planetChoice - 1;

                lastInput = gameTime.TotalGameTime;
            }

            Sun.Update(gameTime);
            Mercury.Update(gameTime);
            Venus.Update(gameTime);
            Earth.Update(gameTime);
            Mars.Update(gameTime);
            Jupiter.Update(gameTime);
            Saturn.Update(gameTime);
            Uranus.Update(gameTime);
            Neptune.Update(gameTime);
            Pluto.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Space.Draw(view, projection, cameraPosition);

            if (planetChoice == 1)
            {
                Sun.Draw(gameTime);
            }

            if (planetChoice == 2)
            {
                Mercury.Draw(gameTime);
            }

            if (planetChoice == 3)
            {
                Venus.Draw(gameTime);
            }

            if (planetChoice == 4)
            {
                Earth.Draw(gameTime);
            }

            if (planetChoice == 5)
            {
                Mars.Draw(gameTime);
            }

            if (planetChoice == 6)
            {
                Jupiter.Draw(gameTime);
            }

            if (planetChoice == 7)
            {
                Saturn.Draw(gameTime);
            }

            if (planetChoice == 8)
            {
                Uranus.Draw(gameTime);
            }

            if (planetChoice == 9)
            {
                Neptune.Draw(gameTime);
            }

            if (planetChoice == 10)
            {
                Pluto.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
