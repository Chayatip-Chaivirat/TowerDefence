using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace Tower_Defence
{
    public class Economy
    {
        Texture2D treasureTexture;
        public int gold;
        Vector2 pos;
        Rectangle texRec;

        public Economy( Vector2 pos) // Constructor for the Economy class
        {
            this.pos = pos;
            texRec = new Rectangle(0,0,195,155);
            gold = 100;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.treasureChestTexture, pos, texRec, Color.White);
        }
    }
}
