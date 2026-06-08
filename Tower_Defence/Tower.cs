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
        public Rectangle towerTexRec;
        private Texture2D towerTexture;
        private int towerDamage;
        private int towerRange;
        private int towerLevel;
        private string towerType;
        public bool isSelected = false; // Flag to determine if the tower is currently selected by the player
        public int towerCost;
        public int upgradeCost;

        Economy economy;

        public Tower(Vector2 pos, string type) // Constructor for the Tower class
        {
            this.towerPos = pos;
            this.towerRange = 0;
            this.towerTexRec = new Rectangle(0, 0, 150, 150); // Default texture rectangle
            this.towerType = type;
            this.towerLevel = 1;
            towerHitbox = new Rectangle((int)towerRange, (int)towerRange, (int)towerRange, (int)towerRange); // Initialize the hitbox with the tower's range
            towerDamage = 0;
            this.towerCost = 0;
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
                if (towerType == "Wooden")
                {
                    towerTexture = AssetManager.woodenTowerLevel1;
                    upgradeCost = 20;
                }
                else if (towerType == "Archer")
                {
                    towerTexture = AssetManager.archerTowerLevel1;
                    upgradeCost = 40;
                }
            }
            else if (towerLevel == 3)
            {
                towerDamage += 30;
                towerRange += 30;
                if (towerType == "Wooden")
                {
                    towerTexture = AssetManager.woodenTowerLevel2;
                    upgradeCost = 30;
                }
                else if (towerType == "Archer")
                {
                    towerTexture = AssetManager.archerTowerLevel2;
                    upgradeCost = 50;
                }
            }
        }

        public void UpgradeTower()
        {
            if (isSelected && towerLevel < 3)
            {
                towerLevel++;
                economy.gold -= upgradeCost; // Deduct the upgrade cost from the player's gold
                DamageBasedOnLevel();
            }
        }

        public void TowerType()
        {
            if (towerType == "Wooden") 
            {
                towerTexture = AssetManager.woodenTowerBaseLevel;
                towerDamage = 10;
                towerRange = 40;
                towerCost = 10;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
                towerTexRec = new Rectangle(0, 0, 150, 150); // Set the texture rectangle for the wooden tower
            }
            else if (towerType == "Archer")
            {
                towerTexture = AssetManager.archerTowerBaseLevel;
                towerDamage = 5;
                towerRange = 90;
                towerCost = 30;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
                towerTexRec = new Rectangle(0, 0, 70, 130); // Set the texture rectangle for the archer tower
            }
        }

        public void Update(GameTime gameTime)
        {
            DamageBasedOnLevel();
            TowerType();
            UpgradeTower();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (TowerPlacementManager.isPlaceable)
            {
                spriteBatch.Draw(towerTexture, towerPos, towerTexRec, Color.White);
            }
            else if (isSelected)
            {
                spriteBatch.Draw(towerTexture, towerPos, towerTexRec, Color.Green * 0.5f); // Draw the tower with a green tint to indicate that it is selected
            }
    }
}
}
