using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar_01.Properties;

namespace TankWar_01
{
    class MyTank:MoveThing
    {
        //创建构造方法
        //1.传递GameObject中的参数 x y
        //2.传递MoveThing中的参数speed speed为一帧移动多少像素的速度
        public MyTank(int x,int y,int speed)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;

            //默认朝向：可以按照默认值赋值
            this.Dir = Direction.Up;

            //坦克的四个方向图片是固定的，直接在构造方法中写
            //传递Movething中的四个方向的set属性
            BitmapDown = Resources.MyTankDown;
            BitmapUp = Resources.MyTankUp;
            BitmapLeft = Resources.MyTankLeft;
            BitmapRight = Resources.MyTankRight;

        }

    }
}
