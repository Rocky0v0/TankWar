using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar_01.Properties;

namespace TankWar_01
{
    class Explosion : GameObject
    {
        //默认播放速度
        private int playSpeed = 2;
        //播放速度计数器
        private int playCount = -1;
        //索引值：用于美实现每张图片播放两帧
        private int index = 0;

        //爆炸图片声明为数组
        private Bitmap[] bmpArray = new Bitmap[]
        {
            Resources.EXP1, Resources.EXP2,Resources.EXP3,Resources.EXP4,Resources.EXP5
        };

        //爆炸效果构造方法
        public Explosion(int x,int y)
        {
            //构造爆炸效果时将图片设为透明
            foreach(Bitmap bmp in bmpArray)
            {
                bmp.MakeTransparent(Color.Black);
            }
            //爆炸位置校准
            this.X = x - bmpArray[0].Width / 2;
            this.Y = y - bmpArray[0].Height / 2;
        }
        protected override Image GetImage()
        {
            if(index>4)return bmpArray[4];
            return bmpArray[index];
        }

        //绘制方法和别的元素不同，爆炸需要绘制几个图片动态切换
        public override void Update()
        {
            playCount++;
            //此公式用于实现每一张图片播放两帧
            index = (playCount - 1) / playSpeed;
            base.Update();
        }
            

            



    }
}
