using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spline;
using System;

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
        private string towerType;

        public Tower(Texture2D tex, Vector2 pos, Rectangle texRec, string type) // Constructor for the Tower class
        {
            this.towerTexture = tex;
            this.towerPos = pos;
            this.towerRange = 0;
            this.towerTexRec = texRec;
            this.towerType = type;
            this.towerLevel = 1;
            towerHitbox = new Rectangle((int)towerRange, (int)towerRange, (int)towerRange, (int)towerRange); // Initialize the hitbox with the tower's range
            towerDamage = 0;
        }

        public void DamageBasedOnLevel()
        {
            if (towerLevel == 1)
            {
                towerDamage += 10;
                towerRange += 10;
            }
            else if (towerLevel == 2)
            {
                towerDamage += 20;
                towerRange += 20;
            }
            else if (towerLevel == 3)
            {
                towerDamage += 30;
                towerRange += 30;
            }
        }

        public void TowerType()
        {
            if (towerType == "Wooden") 
            {
                towerDamage = 10;
                towerRange = 40;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
            }
            else if (towerType == "Archer")
            {
                towerDamage = 5;
                towerRange = 90;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
            }
        }

        public void Update()
        {
            DamageBasedOnLevel();
            TowerType();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(towerTexture, towerPos, towerTexRec, Color.White);
        }
    }
}
