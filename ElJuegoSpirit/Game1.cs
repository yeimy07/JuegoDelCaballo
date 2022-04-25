using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElJuegoSpirit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Rectangle rectangulo1;
        public Rectangle rectangulo2;
        public Rectangle rectangulo3;
        public Rectangle rectangulo4;
        public Rectangle rectangulo5;
        public Texture2D fondo;
        public Texture2D caballito1;
        public Texture2D jinete1;
        public Texture2D piedra1;
        public Texture2D diamante1;
        public int x;
        public int y;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            x = 100;
            y = 300;
            rectangulo1 = new Rectangle(1,1,1000,500);
            rectangulo2 = new Rectangle(301, 300,100, 100);  // para caballito
            rectangulo3 = new Rectangle(601, 300, 100, 100); // para jinete
            rectangulo4 = new Rectangle(81, 300, 200, 100);// para piedra
            rectangulo5 = new Rectangle(31, 300, 50, 50);// para diamante

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo = Content.Load<Texture2D>("fondoo");
            caballito1 = Content.Load<Texture2D>("caballo");
            jinete1 = Content.Load<Texture2D>("jinette01");
            piedra1 = Content.Load<Texture2D>("piedra01");
            diamante1 = Content.Load<Texture2D>("diamante01");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState keysState = Keyboard.GetState();

           

            if (keysState.IsKeyDown(Keys.Left))
            {
                x = x - 10;
                rectangulo2 = new Rectangle(x, y, 100, 100);
            }
            else if (keysState.IsKeyDown(Keys.Right))
            {
                x = x + 10;
                rectangulo2 = new Rectangle(x, y, 100, 100);

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(fondo, rectangulo1, Color.White);
            _spriteBatch.Draw(caballito1, rectangulo2, Color.White);
            _spriteBatch.Draw(jinete1, rectangulo3, Color.White);
            _spriteBatch.Draw(piedra1, rectangulo4, Color.White);
            _spriteBatch.Draw(diamante1, rectangulo5, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
