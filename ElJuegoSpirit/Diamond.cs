using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ElJuegoSpirit
{
    class Diamond : sprites
    {
        private int x = 200;
        private int tiempo = 0;

        Game1 root;//root
        public Diamond(Game1 theRoot, Point laPosicion) : base(laPosicion, new Point(50, 50))
        {

            this.root = theRoot;
            this.LoadContent();

        }

        private void LoadContent()
        {
            imagen = this.root.Content.Load<Texture2D>("diamante01");
        }

        public void Update(GameTime gameTime)
        {
            tiempo++;
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
           // spriteBatch.Draw(imagen, rectangulo, _color);
            try
            {

                if (tiempo > 50 && tiempo < 100) 
                {
                    rectangulo = new Rectangle(x+10, 300, 50, 50);
                    spriteBatch.Draw(imagen, rectangulo, _color);
                }
                if (tiempo > 120 && tiempo < 170)
                {
                    rectangulo = new Rectangle(x + 150, 300, 50, 50);
                    spriteBatch.Draw(imagen, rectangulo, _color);

                }

                if (tiempo > 200 && tiempo < 250)
                {
                    rectangulo = new Rectangle(x + 250, 300, 50, 50);
                    spriteBatch.Draw(imagen, rectangulo, _color);

                }
            }
            catch (DivideByZeroException e)
            {
                Console.Write(" No se puede dividir por cero");
            }


        }

    }

}

