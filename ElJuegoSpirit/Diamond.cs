using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElJuegoSpirit
{
    class Diamond : sprites
    {
 
        Game1 root;//ruta
        public Diamond(Game1 theRoot, Point laPosicion) : base(laPosicion, new Point(50, 50))
        {

            this.root = theRoot;
            this.LoadContent();

        }

        private void LoadContent()
        {
            imagen = this.root.Content.Load<Texture2D>("diamante01");
        }

        public new void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            spriteBatch.Draw(imagen, rectangulo, _color);
        }

        public void Update(GameTime gameTime)
        {

        }
    }

}

