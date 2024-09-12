using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_click_spel;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Enemy enemy;
    Enemy enemy1;
    Enemy enemy2;
    Enemy enemy3;
    Enemy enemy4;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 1700;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        enemy.texture = new Texture2D(GraphicsDevice,1,1);
        enemy.texture.SetData(new Color[]{Color.Red});
        enemy1.texture = new Texture2D(GraphicsDevice,1,1);
        enemy1.texture.SetData(new Color[]{Color.Green});
        enemy2.texture = new Texture2D(GraphicsDevice,1,1);
        enemy2.texture.SetData(new Color[]{Color.Yellow});
        enemy3.texture = new Texture2D(GraphicsDevice,1,1);
        enemy3.texture.SetData(new Color[]{Color.Purple});
        enemy4.texture = new Texture2D(GraphicsDevice,1,1);
        enemy4.texture.SetData(new Color[]{Color.Black});

        enemy = new Enemy(800, 350, enemy.texture);
        enemy1 = new Enemy(210, 400, enemy1.texture);
        enemy2 = new Enemy(500, 250, enemy2.texture);
        enemy3 = new Enemy(1500, 650, enemy3.texture);
        enemy4 = new Enemy(1300, 375, enemy4.texture);
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        //MouseState mouse = Mouse.GetState();

        
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        enemy.Draw(_spriteBatch);
        enemy1.Draw(_spriteBatch);
        enemy2.Draw(_spriteBatch);
        enemy3.Draw(_spriteBatch);
        enemy4.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
