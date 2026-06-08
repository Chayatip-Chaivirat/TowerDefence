using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using Spline;

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
        }
    }
}
