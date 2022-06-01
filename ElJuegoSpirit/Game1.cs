using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace ElJuegoSpirit
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        

         private  int  move = 0;
         public Rectangle rectangulo1;
         public Texture2D fondo;
        private Texture2D imag;
        private Texture2D over;
        private bool menu;
        private int contDiamantes;
        private int vida;
        
        
        public int x;
        public int y;


        // codigo nuevo

        PIEDRUM piedra;
        Horse caballo;
        JinetteEnemigo enemigo;
        Diamond diamante;

        private Song musicaFondo;
        

        private SpriteFont texto;
        private Vector2 posiTexto = new Vector2(370,50);// posicion del texto en pntalla


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

            menu = true;
            vida = 5;
            contDiamantes = 0;

            // nuevo codigo


            piedra = new PIEDRUM(this, new Point(100, 300));
            caballo = new Horse(this);
            enemigo = new JinetteEnemigo(this, new Point(100,300));
            diamante = new Diamond(this, new Point(31, 300));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo = Content.Load<Texture2D>("fondoo");
            imag = Content.Load<Texture2D>("inicio");
            over = Content.Load<Texture2D>("gameOver");
            musicaFondo = Content.Load<Song>("cancion");

            MediaPlayer.Play(musicaFondo);   // para que suene el disco
            MediaPlayer.IsRepeating = true;// para que siempre se repita

            texto = Content.Load<SpriteFont>("letra");// cargando fuente
            



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            

            KeyboardState keysState = Keyboard.GetState();

            if (keysState.IsKeyDown(Keys.Enter))
            {
                menu = false;
            }

            piedra.Update(gameTime);
            caballo.Update(gameTime);
            enemigo.Update(gameTime);
            diamante.Update(gameTime);
            try
            {
                move = move + 1;
                if (move < 50)
                {
                    x = x - 1;
                    rectangulo1 = new Rectangle(x, y, 1050, 500);
                }


                if (move > 50)
                {
                    x = x + 1;
                    rectangulo1 = new Rectangle(x, y, 1050, 500);
                }

                if (move == 100)
                {
                    move = 0;
                }
            }
            catch (DivideByZeroException e)
            {
                Console.Write(" No se puede dividir por cero");
            }
           // colisiones

            if (piedra.rectangulo.Intersects(caballo.rectCaballo))
            {
                vida -= 1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            

            if (menu == true)
            {
                _spriteBatch.Draw(imag, new Rectangle(1, 1, 800, 600), Color.White);
            }
            if (vida < 0)
            {
                _spriteBatch.Draw(over, new Rectangle(1, 1, 800, 600), Color.White);
            }
            else
            {
                _spriteBatch.Draw(fondo, rectangulo1, Color.White);

                // codigo nuevo

                piedra.Draw(gameTime, _spriteBatch, Color.White);
                caballo.Draw(gameTime, _spriteBatch, Color.White);
                enemigo.Draw(gameTime, _spriteBatch, Color.White);
                diamante.Draw(gameTime, _spriteBatch, Color.White);
                _spriteBatch.DrawString(texto, "DIAMANTES "+ contDiamantes + " VIDAS "+ vida, posiTexto, Color.Black);
               // _spriteBatch.DrawString(texto, "SPIRIT", , Color.Black);
              

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
