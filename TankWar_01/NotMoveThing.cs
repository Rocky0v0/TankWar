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

        //提供构造方法用于构造不可移动元素
        public NotMoveThing(int x, int y, Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }

        private Image Img { get; set; }

       
        protected override Image GetImage()
        {
           
            return Img;

        }

        
        


    }
}
