using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace Tower_Defence
{
    public static class AssetManager
    {
        // Boar textures
        public static Texture2D boarAttack;
        public static Texture2D boarWalk;
        public static Texture2D boarHurt;
        public static Texture2D boarDeath;

        // Archer Tower textures
        public static Texture2D archerTowerBaseLevel;
        public static Texture2D archerTowerLevel1;
        public static Texture2D archerTowerLevel2;

        // Wooden Tower textures
        public static Texture2D woodenTowerBaseLevel;
        public static Texture2D woodenTowerLevel1;
        public static Texture2D woodenTowerLevel2;

        // Enemy's goal
        public static Texture2D goalTexture;

        // Enemy's start
        public static Texture2D startPointTexture;

        // Treasure chest 
        public static Texture2D treasureChestTexture;
        public static void LoadTexture(ContentManager content)
        {
            // Boar
            boarAttack = content.Load<Texture2D>("AnimalSprites/PNG/Without_shadow/Boar/Boar_Attack");
            boarWalk = content.Load<Texture2D>("AnimalSprites/PNG/Without_shadow/Boar/Boar_Walk");
            boarHurt = content.Load<Texture2D>("AnimalSprites/PNG/Without_shadow/Boar/Boar_Hurt");
            boarDeath = content.Load<Texture2D>("AnimalSprites/PNG/Without_shadow/Boar/Boar_Death");

            // Archer Tower
            archerTowerBaseLevel = content.Load<Texture2D>("ArcherTowerSprites/2 Idle/2");
            archerTowerLevel1 = content.Load<Texture2D>("ArcherTowerSprites/2 Idle/3");
            archerTowerLevel2 = content.Load<Texture2D>("ArcherTowerSprites/2 Idle/4");

            // Wooden Tower
            woodenTowerBaseLevel = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Tree Stump Tall");
            woodenTowerLevel1 = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Watchtower Short");
            woodenTowerLevel2 = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Watchtower Tall");

            // Goal
            goalTexture = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Tent");

            // Start Point
            startPointTexture = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Bushes Large");

            // Treasure Chest
            treasureChestTexture = content.Load<Texture2D>("VillageAsset/PNG/Top-Down Simple Summer_Prop - Treasure Chest");
        }
    }
}
