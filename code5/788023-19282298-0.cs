    protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
                // TODO: use this.Content to load your game content here
                Player.LoadContent(Content);
            }
