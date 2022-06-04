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

        //添加元素高宽属性
        public int Width { get; set; }
        public int Height { get; set; }
       
        //2.得到image(需要使用抽象方法并在子类中重写得到各个子元素图片)
        protected abstract Image GetImage();

        public void DrawSelf()
        {
      
            Graphics g = GameFramework.g;

            
            g.DrawImage(GetImage(),X,Y);
        }

        //添加虚方法方便子类重写
        public virtual void Update()
        {
            DrawSelf();
        }

        //添加获取矩形方法
        public Rectangle GetRectangle()
        {
            Rectangle rectangle = new Rectangle(X,Y,Width,Height);
            return rectangle;
        }

    }
}
