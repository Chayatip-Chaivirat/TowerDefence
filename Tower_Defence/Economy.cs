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

        public Economy( Vector2 pos, Rectangle texRec) // Constructor for the Economy class
        {
            this.pos = pos;
            this.texRec = texRec;
            gold = 0;
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
