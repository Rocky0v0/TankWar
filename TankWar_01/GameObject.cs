using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TankWar_01
{
    abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        //2.得到image(需要使用抽象方法并在子类中重写得到各个子元素图片)
        protected abstract Image GetImage();

        public void DrawSelf()
        {
      
            Graphics g = GameFramework.g;

            
            g.DrawImage(GetImage(),X,Y);
        }
    }
}
