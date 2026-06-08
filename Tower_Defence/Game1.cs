using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;
using System.Collections.Generic;

namespace Tower_Defence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SimplePath _path;
        Level level;
        Economy economy;

        List<Enemy> enemyList;
        Enemy enemy;

        Tower tower;
        List<Tower> towerList;

        SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _graphics.PreferredBackBufferHeight = 650;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadTexture(Content);
            _path = new SimplePath(GraphicsDevice);
            level = new Level(_path);
            towerList = new List<Tower>();
            enemyList = new List<Enemy>();
            BuildTower();
            economy = new Economy(new Vector2(10, 10));
            SpawnEnemy();
            font = Content.Load<SpriteFont>("Font");
        }

        public void BuildTower()
        {
            // At the mouse's position, create a new tower and add it to the tower list
            // Keybinding: E for Wooden Tower, Q for Archer Tower
            int x = PlayerKeyReader.mouseState.X;
            int y = PlayerKeyReader.mouseState.Y;

            if (PlayerKeyReader.KeyPressed(Keys.E))
            {
                if (TowerPlacementManager.isPlaceable && economy.gold >= tower.towerCost)
                {
                    tower = new Tower(new Vector2(x, y), "Wooden");
                    towerList.Add(tower);
                    economy.gold -= tower.towerCost;
                }
            }
            else if (PlayerKeyReader.KeyPressed(Keys.Q))
            {
                if (TowerPlacementManager.isPlaceable && economy.gold >= tower.towerCost)
                {
                    tower = new Tower(new Vector2(x, y), "Archer");
                    towerList.Add(tower);
                    economy.gold -= tower.towerCost;
                }
            }
        }

        public void SpawnEnemy()
        {
            // Spawn enemies at the beginning of the path and add them to the enemy list
            enemy = new Enemy(_path.GetPos(level.posTex));
            enemyList.Add(enemy);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           foreach (Tower tower in towerList)
            {
                tower.Update(gameTime);
            }

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update(enemyList, gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);

            _spriteBatch.Begin();

            level.Draw(_spriteBatch);
            foreach (Tower tower in towerList)
            {
                tower.Draw(_spriteBatch);
            }

            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(_spriteBatch);
            }

            economy.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, " " + economy.gold, new Vector2(30, 10), Color.DarkGoldenrod);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
