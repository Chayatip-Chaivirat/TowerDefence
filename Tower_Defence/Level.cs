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
        public bool placeableForTower = false; // Not placeable for tower 

        public Level(SimplePath path)   
        {
            this.path = path;
            path.generateDefaultPath();
            posTex = path.beginT;
            placeableForTower = false;
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
