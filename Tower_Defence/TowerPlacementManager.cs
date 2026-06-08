using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public static void PlaceTower()
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
