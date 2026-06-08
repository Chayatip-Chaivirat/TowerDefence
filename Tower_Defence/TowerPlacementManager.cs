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
        public static bool isPlaceable = true;

        public static void NotPlaceableOnOtherTower()
        {
            if (tower.towerTexRec.Intersects(tower.towerTexRec))
            {
                isPlaceable = false;
            }
            else
            {
                isPlaceable = true;
            }
        }

        public static void NotPlaceableOnPath()
        {
            if (!path.placeableForTower)
            {
                isPlaceable = false;
            }
            else
            {
                isPlaceable = true;
            }
        }
    }
}
