using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGuiNet;
using System;

namespace Gui
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ImGuiRenderer GuiRenderer;
        private bool _toolActive;
        System.Numerics.Vector4 _colorV4;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GuiRenderer = new ImGuiRenderer(this);
            _toolActive = true;
            _colorV4 = Color.CornflowerBlue.ToVector4().ToNumerics();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GuiRenderer.RebuildFontAtlas();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(_colorV4));
            _spriteBatch.Begin();
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            GuiRenderer.BeginLayout(gameTime);
            if (_toolActive)
            {
                ImGui.Begin("My First Tool", ref _toolActive, ImGuiWindowFlags.MenuBar);
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.BeginMenu("File"))
                    {
                        if (ImGui.MenuItem("Open..", "Ctrl+O")) { /* Do stuff */ }
                        if (ImGui.MenuItem("Save", "Ctrl+S")) { /* Do stuff */ }
                        if (ImGui.MenuItem("Close", "Ctrl+W")) { _toolActive = false; }
                        ImGui.EndMenu();
                    }
                    ImGui.EndMenuBar();
                }

                // Edit a color stored as 4 floats
                ImGui.ColorEdit4("Color", ref _colorV4);

                // Generate samples and plot them
                var samples = new float[100];
                for (var n = 0; n < samples.Length; n++)
                    samples[n] = (float)Math.Sin(n * 0.2f + ImGui.GetTime() * 1.5f);
                ImGui.PlotLines("Samples", ref samples[0], 100);

                // Display contents in a scrolling region
                ImGui.TextColored(new Vector4(1, 1, 0, 1).ToNumerics(), "Important Stuff");
                ImGui.BeginChild("Scrolling", new System.Numerics.Vector2(0));
                for (var n = 0; n < 50; n++)
                    ImGui.Text($"{n:0000}: Some text");
                ImGui.EndChild();
                ImGui.End();
            }

            GuiRenderer.EndLayout();
        }
    }
}
