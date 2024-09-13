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
        private int enemyAmount = 10;
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

    enemies = new List<Enemy>();

    // Add enemies with non-overlapping positions
    for (int i = 0; i < enemyAmount; i++)
    {
        AddEnemy();
    }
}

        // Method to add an enemy with a non-overlapping position
private void AddEnemy()
{
    Enemy newEnemy;
    bool positionValid;

    do
    {
        // Create a new enemy with a random position
        newEnemy = new Enemy(random.Next(50, windowWidth - 50), random.Next(50, windowHeight - 50), pixel);
        positionValid = true;

        // Check if the new enemy is too close to any existing enemies
        foreach (var enemy in enemies)
        {
            if (IsTooClose(newEnemy.Position, enemy.Position, 200))
            {
                positionValid = false;
                break;
            }
        }

    } while (!positionValid); // Repeat until a valid position is found

    // Add the valid enemy
    enemies.Add(newEnemy);
}


// Method to check if two positions are too close
private bool IsTooClose(Vector2 pos1, Vector2 pos2, float maxDist)
{
    float dx = pos1.X - pos2.X;
    float dy = pos1.Y - pos2.Y;
    return (Math.Abs(dx) < maxDist && Math.Abs(dy) < maxDist);
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
                        AddEnemy();
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
