using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TankWar_01
{
    class NotMoveThing:GameObject
    {

        private Image img;
        public Image Img { get { return img; }
            set { 
                img = value; 
                Width = img.Width;
                Height = img.Height;
                } 
        }

       
        protected override Image GetImage()
        {
           
            return Img;

        }

        //提供构造方法用于构造不可移动元素
        public NotMoveThing(int x, int y, Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }




    }
}
