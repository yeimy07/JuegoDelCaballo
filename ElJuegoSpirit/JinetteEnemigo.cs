using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ElJuegoSpirit
{
    class JinetteEnemigo : sprites
    {

        private int x = 100;
        private int y = 230;
        private int tiempo = 0;
        private int tiempoInterno = 0;
        private int contSalto = 0;
        private int salto = 0;
        Game1 root;// root

        private int CamImage = 0; // para cambiar las imagenes
        private Texture2D[] imageness;

        public JinetteEnemigo(Game1 theRoot, Point laPosicion) : base(laPosicion, new Point(200, 100))
        {
            this.imageness = new Texture2D[3];
            this.root = theRoot;
            this.LoadContent();

        }

        private void LoadContent()
        {

            for (int i = 0; i < 3; i++)
            {
                imageness[i] = this.root.Content.Load<Texture2D>("jine" + (i + 1));
            }
        }

        public void Update(GameTime gameTime)
        {
            var Kstate = Keyboard.GetState();

            try
            {
                tiempo++;
                if (Kstate.IsKeyDown(Keys.B) == true)
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
                if (tiempo % 30 == 0 && contSalto == 1)
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
            }
            catch (DivideByZeroException e)
            {
                Console.Write(" NO se puede dividir por cero");
            }
            

            try
            {
                if (Kstate.IsKeyDown(Keys.Q))
                {
                    if (x < 1000)
                    {
                        CamImage += 1;
                        x += 5;


                        if (CamImage > 2)
                        {
                            CamImage = 0;
                        }
                    }

                }
            }
            catch( FormatException e)
            {
                Console.Write(" debe presionar la tecla derecha");
            }

           
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            spriteBatch.Draw(imageness[CamImage], new Rectangle(x, y, 160, 160), _color);
        }

        

    }
}
