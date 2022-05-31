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
        
        
    }
}
