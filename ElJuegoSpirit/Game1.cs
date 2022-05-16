using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ElJuegoSpirit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

         private  int  move = 0;

        public Rectangle rectangulo1;
       
        //public Rectangle rectangulo3;
        //public Rectangle rectangulo4;
        //public Rectangle rectangulo5;
        public Texture2D fondo;
        //public Texture2D jinete1;
       // public Texture2D piedra1;
        //public Texture2D diamante1;
        public int x;
        public int y;


        // codigo nuevo

        PIEDRUM piedra;
        Horse caballo;
        JinetteEnemigo enemigo;
        Diamond diamante;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            x = -50;
            y = 1;
            rectangulo1 = new Rectangle(x,y,1050,500);
           // rectangulo2 = new Rectangle(301, 300,100, 100);  // para caballito
            //rectangulo3 = new Rectangle(601, 300, 100, 100); // para jinete
           // rectangulo4 = new Rectangle(81, 300, 200, 100);// para piedra
           // rectangulo5 = new Rectangle(31, 300, 50, 50);// para diamante


            // nuevo codigo


            piedra = new PIEDRUM(this, new Point(200, 300));
            caballo = new Horse(this);
            enemigo = new JinetteEnemigo(this, new Point(100,100));
            diamante = new Diamond(this, new Point(31, 300));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo = Content.Load<Texture2D>("fondoo");
            //caballito1 = Content.Load<Texture2D>("caballo");
            //jinete1 = Content.Load<Texture2D>("jinette01");
           // piedra1 = Content.Load<Texture2D>("piedra01");
            //diamante1 = Content.Load<Texture2D>("diamante01");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState keysState = Keyboard.GetState();

            piedra.Update(gameTime);
            caballo.Update(gameTime);
            enemigo.Update(gameTime);
            diamante.Update(gameTime);
            
            move = move + 1;
            if (move < 50)
            {
                x = x - 1;
                rectangulo1 = new Rectangle(x, y, 1050, 500);
            }


            if (move>50)
            {
                x = x + 1;
                rectangulo1 = new Rectangle(x, y, 1050, 500);
            }

            if (move == 100)
            {
                move = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(fondo, rectangulo1, Color.White);
            
           // _spriteBatch.Draw(jinete1, rectangulo3, Color.White);
            //_spriteBatch.Draw(piedra1, rectangulo4, Color.White);
           // _spriteBatch.Draw(diamante1, rectangulo5, Color.White);

            // codigo nuevo

            piedra.Draw(gameTime, _spriteBatch, Color.White);
            caballo.Draw(gameTime, _spriteBatch, Color.White);
            enemigo.Draw(gameTime, _spriteBatch, Color.White);
            diamante.Draw(gameTime, _spriteBatch, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
