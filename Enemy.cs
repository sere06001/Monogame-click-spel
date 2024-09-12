using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_click_spel
{
    public class Enemy
    {
        Vector2 position = new Vector2(0, 0);
        public Texture2D texture;
        Rectangle enemy = new Rectangle(0, 0, 0, 0);
        public Enemy(int x, int y, Texture2D texture)
        {
            position = new Vector2(x, y);
            this.texture = texture;
            enemy = new Rectangle((int)position.X-50, (int)position.Y-50, 100, 100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, enemy, Color.AliceBlue);
        }
    }
}