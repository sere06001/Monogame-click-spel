using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame_click_spel;
using SharpDX.DXGI;
using SharpDX.MediaFoundation;

public class Enemy
{
    Vector2 position;
    public Texture2D texture;
    Rectangle enemy;

    public Enemy(int x, int y, Texture2D texture)
    {
        this.texture = texture;
        if (x > 50 && x < Game1.windowWidth && y > 50 && y < Game1.windowHeight)
        {
            position = new Vector2(x, y);
        }
        else
        {
            if (x < 50)
            {
                x = 50;
            }
            if (y < 50)
            {
                y = 50;
            }
            if (x > Game1.windowWidth)
            {
                x = Game1.windowWidth - 50;
            }
            if (y > Game1.windowHeight)
            {
                y = Game1.windowHeight - 50;
            }
            position = new Vector2(x, y);
        }
        
        enemy = new Rectangle((int)position.X - 50, (int)position.Y - 50, 100, 100);
    }

    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (texture != null)
        {
            spriteBatch.Draw(texture, enemy, Color.AliceBlue);
        }
    }

    public bool IsClicked(Point mousePosition)
    {
        return enemy.Contains(mousePosition);
    }
}
