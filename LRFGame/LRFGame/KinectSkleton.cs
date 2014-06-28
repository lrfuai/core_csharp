using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Kinect;

using LRFLibrary.Functional.Modules;
using LRFLibrary.Functional;

namespace LRFGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class KinectSkleton : Microsoft.Xna.Framework.Game
    {

        /// <summary>
        /// This is used to adjust the window size.
        /// </summary>
        private const int Width = 800;

        /// <summary>
        /// This controls the transition time for the resize animation.
        /// </summary>
        private const double TransitionDuration = 1.0;

        /// <summary>
        /// The graphics device manager provided by Xna.
        /// </summary>
        private readonly GraphicsDeviceManager graphics;

        /// <summary>
        /// This control selects a sensor, and displays a notice if one is
        /// not connected.
        /// </summary>
        private readonly KinectChooser chooser;

        /// <summary>
        /// This manages the rendering of the color stream.
        /// </summary>
        private readonly ColorStreamRenderer colorStream;

        /// <summary>
        /// This manages the rendering of the depth stream.
        /// </summary>
        private readonly DepthStreamRenderer depthStream;

        /// <summary>
        /// This is the location of the color stream when minimized.
        /// </summary>
        private readonly Vector2 colorSmallPosition;

        /// <summary>
        /// This is the location of the depth stream when minimized;
        /// </summary>
        private readonly Vector2 depthSmallPosition;

        /// <summary>
        /// This is the minimized size for both streams.
        /// </summary>
        private readonly Vector2 minSize;

        /// <summary>
        /// This is the viewport of the streams.
        /// </summary>
        private readonly Rectangle viewPortRectangle;

        /// <summary>
        /// This is the SpriteBatch used for rendering the header/footer.
        /// </summary>
        private SpriteBatch spriteBatch;

        /// <summary>
        /// This tracks the state to indicate which stream has focus.
        /// </summary>
        private bool colorHasFocus = true;

        /// <summary>
        /// This tracks the previous keyboard state.
        /// </summary>
        private KeyboardState previousKeyboard;

        /// <summary>
        /// This tracks the current transition time.
        /// 0                   = Color Stream Full Focus
        /// TransitionDuration  = Depth Stream Full Focus
        /// </summary>
        private double transition;

        /// <summary>
        /// This is the texture for the header.
        /// </summary>
        private Texture2D header;

        /// <summary>
        /// This is the font for the footer.
        /// </summary>
        private SpriteFont font;

        //public RobotHandlerModule Follower;
        //public PeopleFollowerModule Follower;
        public ArmHandlerModule ArmHandler;

        public KinectSkleton()
        {
            //this.Follower = new RobotHandlerModule(FunctionalFaccade.getInstance().SkeletalTracker(), FunctionalFaccade.getInstance().Navigator());
            //(FunctionalFaccade.getInstance().SkeletalTracker(), FunctionalFaccade.getInstance().Navigator());
            this.ArmHandler = new ArmHandlerModule(FunctionalFaccade.getInstance().SkeletalSelector(), FunctionalFaccade.getInstance().Arm());
            this.ArmHandler.run();
            this.IsFixedTimeStep = false;
            this.IsMouseVisible = true;
            this.Window.Title = "Laboratorio Robótica Física de la UAI";

            // This sets the width to the desired width
            // It also forces a 4:3 ratio for height
            // Adds 110 for header/footer
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = Width;
            this.graphics.PreferredBackBufferHeight = ((Width / 4) * 3) + 110;
            this.graphics.PreparingDeviceSettings += this.GraphicsDevicePreparingDeviceSettings;
            this.graphics.SynchronizeWithVerticalRetrace = true;
            this.viewPortRectangle = new Rectangle(10, 80, Width - 20, ((Width - 2) / 4) * 3);

            Content.RootDirectory = "Content";

            // The Kinect sensor will use 640x480 for both streams
            // To make your app handle multiple Kinects and other scenarios,
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            this.chooser = new KinectChooser(this, ColorImageFormat.RgbResolution640x480Fps30, DepthImageFormat.Resolution640x480Fps30);
            this.Services.AddService(typeof(KinectChooser), this.chooser);

            // Default size is the full viewport
            this.colorStream = new ColorStreamRenderer(this, this.ArmHandler);

            // Calculate the minimized size and location
            this.depthStream = new DepthStreamRenderer(this, this.ArmHandler);
            this.depthStream.Size = new Vector2(this.viewPortRectangle.Width / 4, this.viewPortRectangle.Height / 4);
            this.depthStream.Position = new Vector2(Width - this.depthStream.Size.X - 15, 85);

            // Store the values so we can animate them later
            this.minSize = this.depthStream.Size;
            this.depthSmallPosition = this.depthStream.Position;
            this.colorSmallPosition = new Vector2(15, 85);

            this.Components.Add(this.chooser);

            this.previousKeyboard = Keyboard.GetState();

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
            this.Components.Add(this.depthStream);
            this.Components.Add(this.colorStream);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.Services.AddService(typeof(SpriteBatch), this.spriteBatch);

            this.header = Content.Load<Texture2D>("Header");
            this.font = Content.Load<SpriteFont>("Segoe16");

            base.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            base.Update(gameTime);

            // If the spacebar has been pressed, toggle the focus
            KeyboardState newState = Keyboard.GetState();
            if (this.previousKeyboard.IsKeyUp(Keys.Space) && newState.IsKeyDown(Keys.Space))
            {
                this.colorHasFocus = !this.colorHasFocus;
            }

            this.previousKeyboard = newState;

            // Animate the transition value
            if (this.colorHasFocus)
            {
                this.transition -= gameTime.ElapsedGameTime.TotalSeconds;
                if (this.transition < 0)
                {
                    this.transition = 0;
                }
            }
            else
            {
                this.transition += gameTime.ElapsedGameTime.TotalSeconds;
                if (this.transition > TransitionDuration)
                {
                    this.transition = TransitionDuration;
                }
            }

            // Animate the stream positions and sizes
            this.colorStream.Position = Vector2.SmoothStep(
                new Vector2(this.viewPortRectangle.X, this.viewPortRectangle.Y),
                this.colorSmallPosition,
                (float)(this.transition / TransitionDuration));
            this.colorStream.Size = Vector2.SmoothStep(
                new Vector2(this.viewPortRectangle.Width, this.viewPortRectangle.Height),
                this.minSize,
                (float)(this.transition / TransitionDuration));

            this.depthStream.Position = Vector2.SmoothStep(
                this.depthSmallPosition,
                new Vector2(this.viewPortRectangle.X, this.viewPortRectangle.Y),
                (float)(this.transition / TransitionDuration));
            this.depthStream.Size = Vector2.SmoothStep(
                this.minSize,
                new Vector2(this.viewPortRectangle.Width, this.viewPortRectangle.Height),
                (float)(this.transition / TransitionDuration));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen
            GraphicsDevice.Clear(Color.White);

            // Render header/footer
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.header, Vector2.Zero, null, Color.White);
            this.spriteBatch.DrawString(this.font, "Press [Space] to switch between color and depth.", new Vector2(10, this.viewPortRectangle.Y + this.viewPortRectangle.Height + 3), Color.Black);
            this.spriteBatch.End();

            // Render the streams with respect to focus
            if (this.colorHasFocus)
            {
                this.colorStream.DrawOrder = 1;
                this.depthStream.DrawOrder = 2;
            }
            else
            {
                this.colorStream.DrawOrder = 2;
                this.depthStream.DrawOrder = 1;
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// This method ensures that we can render to the back buffer without
        /// losing the data we already had in our previous back buffer.  This
        /// is necessary for the SkeletonStreamRenderer.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event args.</param>
        private void GraphicsDevicePreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            // This is necessary because we are rendering to back buffer/render targets and we need to preserve the data
            e.GraphicsDeviceInformation.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
        }
    }
}
