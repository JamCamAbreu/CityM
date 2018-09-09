using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace CityM {
  public class CityM : Game {

    // Member Variables:
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    // Dictionaries for easy access to assets:
    public Dictionary<CityConstants.backgrounds, Texture2D> backgrounds = new Dictionary<CityConstants.backgrounds, Texture2D>();
    public Dictionary<CityConstants.sprites, Texture2D> sprites = new Dictionary<CityConstants.sprites, Texture2D>();
    public Dictionary<CityConstants.music, Song> songs = new Dictionary<CityConstants.music, Song>();
    public Dictionary<CityConstants.soundEffects, SoundEffect> sfx = new Dictionary<CityConstants.soundEffects, SoundEffect>();








    // Constructor:
    public CityM() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Pass in a reference to itself
            //manager = new GameStateManager(this);

            graphics.PreferredBackBufferWidth = CityConstants.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = CityConstants.SCREEN_HEIGHT;
    } // end constructor



    protected override void Initialize() {

        // TODO: Add your initialization logic here

        base.Initialize();
    } // end Initialize


    protected override void LoadContent() {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);

      // TODO: use this.Content to load your game content here


      // Main Menu:
      backgrounds.Add(CityConstants.backgrounds.title, Content.Load<Texture2D>("backgrounds/bg_title"));



    } // end loadContent


    protected override void UnloadContent() {
        // TODO: Unload any non ContentManager content here
    } // end UnloadContent


    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    } // end Update


    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    } // end Draw


  } // end CityM class
}
