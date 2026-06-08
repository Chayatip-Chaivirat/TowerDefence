using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;
namespace Tower_Defence
{
    public static class TowerPlacementManager
    {
        static Level path;
        static Tower tower;

        public static void NotPlaceableOnOtherTower()
        {
            if (tower.towerTexRec.Intersects(tower.towerTexRec))
            {
                tower.isPlaceable = false;
            }
            else
            {
                tower.isPlaceable = true;
            }
        }

        public static void NotPlaceableOnPath()
        {
            if (!path.placeableForTower)
            {
                tower.isPlaceable = false;
            }
            else
            {
                tower.isPlaceable = true;
            }
        }
    }
}
