

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace ElJuegoSpirit
{
    class Horse
    {
        public int x = 100;
        public int y = 230;
        private int tiempo = 0;
        private int tiempoInterno = 0;
        private int contSalto = 0;
        private int salto = 0;
        SoundEffect relincheCaballo;
        public Rectangle rectCaballo = new Rectangle(100, 250, 160 ,160);

        // codigo ensayo pa que salte
        Game1 root; // ruta

        private int CamImage = 0; // para cambiar las imagenes
        private Texture2D[] imagenes;

        public Horse(Game1 theRoot)
        {
            this.imagenes = new Texture2D[3];
            this.root = theRoot;
            
        

            this.LoadContent();

        }

        private void LoadContent()
        {

            for (int i = 0; i < 3; i++)
            {
                imagenes[i] = this.root.Content.Load<Texture2D>("c" + (i + 1));
            }

            relincheCaballo = this.root.Content.Load<SoundEffect>("relinche");
        }

        public void Update(GameTime gameTime)
        {
            var Kstate = Keyboard.GetState();
            rectCaballo.X = x;
            rectCaballo.Y = y;
      
            try
            {
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
                if (tiempo % 50 == 0 && contSalto == 1)
                {
                    CamImage += 1;//todrau
                    x += 100;
                    y += 200;
                    relincheCaballo.Play();

                    contSalto = 0;
                    if (CamImage >= 2)
                    {
                        CamImage = 0;
                    }
                }
            }
            catch(DivideByZeroException e)
            {
                Console.Write(" no se puede dividir por cero");
            }
            

            try
            {
                if (Kstate.IsKeyDown(Keys.Right))// para que el caballo avance
                {
                    if (x < 1000)
                    {
                        CamImage += 1;
                        x += 5;


                        if (CamImage > 2)
                        {
                            CamImage = 0;
                        

                      //  if (x <= 50)// para que no se salga de la pantalla
                       // {
                            //x = 100;
                               // y = 230;
                        //}
                    }
                    }

                }
            }
            catch (FormatException e)
            {
                Console.Write(" debe presionar la tecla derecha");
            }
            

            
        }

      
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {

            spriteBatch.Draw(imagenes[CamImage], rectCaballo, _color);
        }
    

        
    }



}

