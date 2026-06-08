using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public Tower(Texture2D tex, Vector2 pos, int damage, int range, Rectangle texRec) // Constructor for the Tower class
        {
            this.towerTexture = tex;
            this.towerPos = pos;
            this.towerDamage = damage;
            this.towerRange = range;
            this.towerTexRec = texRec;
            this.towerLevel = 1;
            towerHitbox = new Rectangle((int)range, (int)range, (int)range, (int)range); // Initialize the hitbox with the tower's range
        }
    }
}
