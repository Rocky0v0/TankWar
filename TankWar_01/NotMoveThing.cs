using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TankWar_01
{
    class NotMoveThing:GameObject
    {
        public Image Img;
      
        

        protected override Image GetImage()
        {
            Img = Image.FromFile("C:\\Users\\PC\\Desktop\\TankWar\\img\\Images\\wall.jpg");
            return Img;
        }

        //提供构造方法用于构造不可移动元素
        public NotMoveThing(int x,int y,Image img)
        {
            this.X = x;
            this.Y = y;
            this.Img = img;
        }

        


    }
}
