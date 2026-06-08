using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spline;
using System.Collections.Generic;

namespace Tower_Defence
{
    public class Enemy
    {
        private Texture2D enemyTexture;
        private Vector2 enemyPos;
        private Rectangle enemyTexRec;
        private int enemyHealth;
        private int enemyDamage;
        private int enemySpeed;
        private int enemyLevel;
        public Enemy(Texture2D tex, Vector2 pos, Rectangle texRec) // Constructor for the Enemy class
        {
            this.enemyTexture = tex;
            this.enemyPos = pos;
            this.enemyTexRec = texRec;
            enemyLevel = 1;
            enemyDamage = 0;
            enemyHealth = 0;
            enemySpeed = 0;
        }

        public void DamageBasedOnLevel()
        {
            if (enemyLevel == 1)
            {
                enemyHealth += 10;
                enemyDamage += 10;
                enemySpeed += 2;
            }
            else if (enemyLevel == 2)
            {
                enemyHealth += 20;
                enemyDamage += 20;
                enemySpeed += 4;
            }
            else if (enemyLevel == 3)
            {
                enemyHealth += 30;
                enemyDamage += 30;
                enemySpeed += 6;
            }
        }

        public void Update(List<Enemy> enemies, GameTime gameTime)
        {
            DamageBasedOnLevel();
            OnDestroy(enemies);
        }

        public void OnDestroy(List<Enemy> enemies)
        {
            if (enemyHealth <= 0)
            {
                enemies.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyPos, enemyTexRec, Color.White);
        }
    }
}
