using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Monogame_click_spel
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D pixel;
        private List<Enemy> enemies;
        static private Random random = new Random();
        //private int randomLimitH = random.Next(50, windowHeight - 50);
        //private int randomLimitW = random.Next(50, windowWidth - 50);
        static public int windowHeight = 900;
        static public int windowWidth = 1500;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.Red });

            enemies = new List<Enemy>
            {
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel),
                new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel)
            };

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouseState = Mouse.GetState();
            Point mousePosition = mouseState.Position;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // Check if any enemy is clicked
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (enemies[i].IsClicked(mousePosition))
                    {
                        // Remove the clicked enemy
                        enemies.RemoveAt(i);
                        enemies.Add(new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel));
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (var enemy in enemies)
            {
                enemy.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
