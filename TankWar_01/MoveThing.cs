using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar_01
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }
    internal class MoveThing:GameObject
    {
        public int Speed { get; set; }

        public Direction Dir { get; set; }

        public Bitmap BitmapUp { get; set; }
        public Bitmap BitmapDown { get; set; }
        public Bitmap BitmapRight { get; set; }
        public Bitmap BitmapLeft { get; set; }

        protected override Image GetImage()
        {
            Bitmap bitmap = null;

            switch(Dir)
            {
                case Direction.Up:
                    bitmap = BitmapUp;
                    break;
                case Direction.Down:
                    bitmap = BitmapDown;
                    break;
                case Direction.Right:
                    bitmap = BitmapRight;
                    break;
                case Direction.Left:
                    bitmap = BitmapLeft;
                    break;

            }
            bitmap.MakeTransparent(Color.Black);
            return bitmap;


           
            
        }
    }
}
