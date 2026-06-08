using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spline;
using System;
using System.Diagnostics.Eventing.Reader;

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
            this.towerTexRec = new Rectangle(0, 0, 150, 150); // Default texture rectangle
            this.towerType = type;
            this.towerLevel = 1;
            towerHitbox = new Rectangle((int)towerRange, (int)towerRange, (int)towerRange, (int)towerRange); // Initialize the hitbox with the tower's range
            TowerType();
            economy = new Economy(new Vector2(10, 10)); // Initialize the economy object
        }

        public void DamageBasedOnLevel()
        {
            if (towerLevel == 1)
            {
                if (towerType == "Wooden")
                {
                    towerDamage = 10;
                    towerRange = 50;
                }
                else if (towerType == "Archer")
                {
                    towerDamage = 5;
                    towerRange = 100;
                }
            }
            else if (towerLevel == 2)
            {
                if (towerType == "Wooden")
                {
                    towerTexture = AssetManager.woodenTowerLevel1;
                    towerDamage = 30;
                    towerRange = 60;
                    upgradeCost = 20;
                }
                else if (towerType == "Archer")
                {
                    towerTexture = AssetManager.archerTowerLevel1;
                    towerDamage = 25;
                    towerRange = 110;
                    upgradeCost = 40;
                }
            }
            else if (towerLevel == 3)
            {
                if (towerType == "Wooden")
                {
                    towerTexture = AssetManager.woodenTowerLevel2;
                    towerDamage = 40;
                    towerRange = 70;
                    upgradeCost = 30;
                }
                else if (towerType == "Archer")
                {
                    towerTexture = AssetManager.archerTowerLevel2;
                    towerDamage = 35;
                    towerRange = 120;
                    upgradeCost = 50;
                }
            }
        }

        public void SelectTower()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && towerHitbox.Contains(Mouse.GetState().Position))
            {
                isSelected = true; // Set the tower as selected when the player clicks on it
            }
            else
            {
                isSelected = false; // Set the tower as not selected when the player clicks elsewhere
            }
        }

        public void UpgradeTower()
        {
            if (towerLevel < 3 && economy.gold >= upgradeCost)
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
                towerCost = 10;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
                towerTexRec = new Rectangle(0, 0, 150, 150); // Set the texture rectangle for the wooden tower
            }
            else if (towerType == "Archer")
            {
                towerTexture = AssetManager.archerTowerBaseLevel;
                towerCost = 30;
                towerHitbox = new Rectangle((int)towerPos.X - towerRange, (int)towerPos.Y - towerRange, (int)towerRange * 2, (int)towerRange * 2); // Update the hitbox based on the tower's position and range
                towerTexRec = new Rectangle(0, 0, 70, 130); // Set the texture rectangle for the archer tower
            }
        }

        public void Update(GameTime gameTime)
        {
            DamageBasedOnLevel();
            TowerType();
            SelectTower();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = isSelected ? Color.Green * 0.5f : Color.White; // Change the color of the tower when it is selected
            float scale = (towerType == "Wooden" ? 0.3f : 0.8f); // Set the scale based on the tower type

            spriteBatch.Draw(towerTexture, towerPos, towerTexRec, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
