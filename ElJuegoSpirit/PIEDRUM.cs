using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElJuegoSpirit
{
    class PIEDRUM : sprites
    {
        private int x = 300;
        private int tiempo =0;
        Game1 root;//ruta
        public PIEDRUM ( Game1 theRoot, Point laPosicion): base( laPosicion, new Point (200, 100))
        {

            this.root = theRoot;
            this.LoadContent();

        }

        private void LoadContent()
        {
            imagen = this.root.Content.Load<Texture2D>("piedra01");
        }

        public void Update(GameTime gameTime)
        {
            tiempo++;
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            if (tiempo>50 && tiempo < 100)
            {
                rectangulo = new Rectangle(x, 300, 200, 100);
                spriteBatch.Draw(imagen, rectangulo, _color);
            }
            if( tiempo> 120 && tiempo< 170)
            {
                rectangulo = new Rectangle(x + 150, 300, 200, 100);
                spriteBatch.Draw(imagen, rectangulo, _color);

            }

            if (tiempo > 200&& tiempo < 250)
            {
                rectangulo = new Rectangle(x + 350, 300, 200, 100);
                spriteBatch.Draw(imagen, rectangulo, _color);

            }



        }

        
    }
}
