using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ElJuegoSpirit
{
    class sprites
    {
        protected Point posicion { get; set; }

        public Point size { get; set; }

        protected string imagen1;
        protected Texture2D imagen;

        public Rectangle rectangulo;

        public sprites(Point _posicion, Point _size)
        {
            this.posicion = _posicion;
            size = size;
            rectangulo = new Rectangle(posicion, _size);
        }


        public  void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color _color)
        {
            spriteBatch.Draw(imagen, rectangulo, _color);
        }

    }
}
