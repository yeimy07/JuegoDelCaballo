

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElJuegoSpirit
{
    class Horse 
    {
        public Rectangle rectangulo;
       // public Point position { get; set; }
        Game1 root; // ruta
        private int positiCaballoNoSalir = 300;
        private int CamImage = 0; // para cambiar las imagenes
        private Texture2D[] imagenes;

        public Horse(Game1 theRoot, Point laPosicion) 
        {
           // this.position = laPosicion;
            this.imagenes = new Texture2D[3];
            this.root = theRoot;
            this.LoadContent();
            rectangulo = new Rectangle(positiCaballoNoSalir, 300, 100, 100);
        }

        private void LoadContent()
        {
            
            for (int  i= 0;  i< 2; i ++)
            {
                imagenes[i] = this.root.Content.Load<Texture2D>("c"+ (i+1));
            }
        }

        public void Update(GameTime gameTime)
        {
            var Kstate = Keyboard.GetState();
            

            if (Kstate.IsKeyDown(Keys.Right))
            {
                if (positiCaballoNoSalir < 1000)
                {
                    CamImage += 1;
                    positiCaballoNoSalir += 5;
                    rectangulo= new Rectangle(positiCaballoNoSalir, 300, 100, 100);

                    if (CamImage>2)
                    {
                        CamImage = 0;
                    }
                }

            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            
            spriteBatch.Draw(imagenes[CamImage], rectangulo, _color);
        }

        
    }



}

