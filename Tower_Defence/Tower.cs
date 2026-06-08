using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spline;

namespace Tower_Defence
{
    public class Tower
    {
        private Vector2 towerPos;
        private Rectangle towerHitbox;
        private Rectangle towerTexRec;
        private Texture2D towerTexture;
        private int towerDamage;
        private int towerRange;
        private int towerLevel;

        public Tower(Texture2D tex, Vector2 pos, int range, Rectangle texRec) // Constructor for the Tower class
        {
            this.towerTexture = tex;
            this.towerPos = pos;
            this.towerRange = range;
            this.towerTexRec = texRec;
            this.towerLevel = 1;
            towerHitbox = new Rectangle((int)range, (int)range, (int)range, (int)range); // Initialize the hitbox with the tower's range
        }

        public void DamageBasedOnLevel()
        {
            if (towerLevel == 1)
            {
                towerDamage = 10;
            }
            else if (towerLevel == 2)
            {
                towerDamage = 20;
            }
            else if (towerLevel == 3)
            {
                towerDamage = 30;
            }
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(towerTexture, towerPos, towerTexRec, Color.White);
        }
    }
}
