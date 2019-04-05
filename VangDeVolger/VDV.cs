using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace VangDeVolger
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class VDV : Game
    {
        Texture2D tile;
        Texture2D box;
        Texture2D wall;
        Texture2D player;
        Texture2D empty;
        Texture2D enemy;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PlayingField playingField;

        KeyboardState previousState;
            
        public VDV()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            playingField = new PlayingField(16, 16);

            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tile = Content.Load<Texture2D>("tile");
            player = Content.Load<Texture2D>("player");
            box = Content.Load<Texture2D>("box");
            wall = Content.Load<Texture2D>("wall");
            enemy = Content.Load<Texture2D>("enemy");
            empty = Content.Load<Texture2D>("empty");

            graphics.PreferredBackBufferWidth = 900;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();





            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No Keys pressed");


             if (state.IsKeyDown(Keys.Up) && !previousState.IsKeyDown(Keys.Up))
                playingField.player.CheckNeighbours("top");
            if (state.IsKeyDown(Keys.Right) && !previousState.IsKeyDown(Keys.Right))
                playingField.player.CheckNeighbours("right");
            if (state.IsKeyDown(Keys.Down) && !previousState.IsKeyDown(Keys.Down))
                playingField.player.CheckNeighbours("bottom");
            if (state.IsKeyDown(Keys.Left) && !previousState.IsKeyDown(Keys.Left))
                playingField.player.CheckNeighbours("left");

            base.Update(gameTime);

            previousState = state;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            for (int i = 0; i < playingField.Height; i++)
            {
                for (int j = 0; j < playingField.Width; j++)
                {
                    spriteBatch.Draw(tile, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);

                    if (playingField.TileGrid[i, j].Contains != null && playingField.TileGrid[i, j].Contains.IsWall)
                    {
                        spriteBatch.Draw(wall, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);
                    }

                    else if (playingField.TileGrid[i, j].ContainsPlayer is Player)
                    {
                        spriteBatch.Draw(player, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);
                    }

                    else if (playingField.TileGrid[i, j].ContainsEnemy is Enemy)
                    {
                        spriteBatch.Draw(enemy, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);
                    }

                    else if (playingField.TileGrid[i, j].Contains != null && playingField.TileGrid[i, j].Contains.IsBox)
                    {
                        spriteBatch.Draw(box, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);
                    }

                    else if (playingField.TileGrid[i, j].Contains != null && playingField.TileGrid[i, j].Contains.IsTile)
                    {
                        spriteBatch.Draw(tile, new Rectangle((10 + (i * playingField.TileGrid[i, j].tileSize)), (10 + (j * playingField.TileGrid[i, j].tileSize)), 50, 50), new Rectangle(0, 0, tile.Width, tile.Height), Color.White);
                    }
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
