

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElJuegoSpirit
{
    class Horse 
    {
        public int x = 100;
        public int y = 100;
        private int tiempo = 0;
        private int tiempoInterno=0;
        private int contSalto =0;
        private int salto = 0;
       // public Point position { get; set; }
        Game1 root; // ruta
        
        private int CamImage = 0; // para cambiar las imagenes
        private Texture2D[] imagenes;

        public Horse(Game1 theRoot) 
        {
           // this.position = laPosicion;
            this.imagenes = new Texture2D[3];
            this.root = theRoot;
         
            this.LoadContent();
          
        }

        private void LoadContent()
        {
            
            for (int  i= 0;  i< 3; i ++)
            {
                imagenes[i] = this.root.Content.Load<Texture2D>("c"+ (i+1));
            }
        }

        public void Update(GameTime gameTime)
        {
            var Kstate = Keyboard.GetState();

            tiempo++;
            if (Kstate.IsKeyDown(Keys.Space) == true)
            {
               
                salto = 1;
               
            }
            if (salto == 1)
            {

                CamImage = 1;
                y -= 100;
                salto = 0;
                contSalto = 1;
                
            }
            if (tiempo%30==0 && contSalto ==1)
            {
                CamImage += 1;//todrau
                x += 100;
                y += 200;

                contSalto = 0;
                if (CamImage >= 2)
                {
                    CamImage = 0;
                }
            }
           


            if (Kstate.IsKeyDown(Keys.Right))
            {
                if (x < 1000)
                {
                    CamImage += 1;
                   x += 5;
                   

                    if (CamImage>2)
                    {
                        CamImage = 0;
                    }
                }

            }
        }


        

public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            
            spriteBatch.Draw(imagenes[CamImage], new Rectangle(x,y, 300,200), _color);
        }

        
    }



}

