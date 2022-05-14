using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ElJuegoSpirit
{
    class JinetteEnemigo : sprites
    {
        Game1 root;//ruta
        public JinetteEnemigo(Game1 theRoot, Point laPosicion) : base(laPosicion, new Point(200, 100))
        {

            this.root = theRoot;
            this.LoadContent();

        }

        private void LoadContent()
        {
            imagen = this.root.Content.Load<Texture2D>("jine1");
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
