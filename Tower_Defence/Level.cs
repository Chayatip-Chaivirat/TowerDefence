using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace Tower_Defence
{
    public class Level
    {
        SimplePath path;
        float posTex;
        
        public Level(SimplePath path)   
        {
            this.path = path;
            path.generateDefaultPath();
            posTex = path.beginT;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            path.Draw(spriteBatch);
        }
    }
}
