﻿

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
       // public Point position { get; set; }
       // Vector2 position;
       // Vector2 velocity;

        //bool Hasjumped;
         


        // codigo ensayo pa que salte
        Game1 root; // ruta
        
        private int CamImage = 0; // para cambiar las imagenes
        private Texture2D[] imagenes;

        public Horse(Game1 theRoot) 
        {
           //this.position = laPosicion;
            this.imagenes = new Texture2D[3];
            this.root = theRoot;
           // this.position = newposition;
           // this.Hasjumped = true;
         
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
           // position += velocity;

           // if (Keyboard.GetState().IsKeyDown(Keys.Right)) velocity.X = 3f;
           // else (Keyboard.GetState().IsKeyDown(Keys.Left) velocity.Y = -3f; else velocity.X = 0f;

           // if (Keyboard.GetState().IsKeyDown(Keys.Space) && Hasjumped == false)
           // {
               // position.Y -= 10f;
               // velocity.Y = -5f;
               // Hasjumped = true;

            //}

           // if ( Hasjumped == true)
           // {
               // float i = 1;
            //    velocity.Y += 0.15f * i;

           // }

           // if( position.Y + Texture.Height >= 450)
            //{
            //    Hasjumped = true;
            //}

           // if (Hasjumped == false)
           // {
           //     velocity.Y = 0f;

           // }




        
            

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
            
            spriteBatch.Draw(imagenes[CamImage], new Rectangle(x,y, 160,160), _color);
        }

        
    }



}

