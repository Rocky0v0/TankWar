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
            //每个子类元素需要绘制自身方法将自身绘制在画布上

            //此方法需要先得到画布,传递图片参数，坐标参数

            //1.得到画布
            Graphics g = GameFramework.g;

            //Graphics类中的绘制方法
            g.DrawImage(GetImage(),X,Y);
        }
    }
}
