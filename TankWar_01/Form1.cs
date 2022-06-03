using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWar_01
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics windowG;
        private static Bitmap tempBmp;


        public Form1()
        {
            
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            //得到窗体画布，但是先不绘制元素，变为使用下方的临时图片创建的临时画布绘制元素，再放置在窗体画布中
            windowG = this.CreateGraphics();
            //GameFramework.g = g;

            //解决元素闪烁问题(新建黑色图片并将元素先绘制在图片上再将该图片绘制在画布g上，代替原有的直接将元素绘制在画布g上)
            //1.生成临时图片
            tempBmp = new Bitmap(450, 450);
            //静态方法(工具方法)
            //2.根据临时图片生成临时画布bmpG
            Graphics bmpG = Graphics.FromImage(tempBmp);
            //3.在临时画布bmpG上绘制元素就会绘制到tempBmp图片上
            //此时GameFramework中的g改为了对应的画布改为了临时画布
            GameFramework.g = bmpG;

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        } 

        private static void GameMainThread()
        {
            GameFramework.Start();

            int sleepTime = 1000 / 60;

            while (true)
            {
               
               //在临时画布上作画
                GameFramework.g.Clear(Color.Black);

                GameFramework.Update();

                //4.最终将临时画布上的元素绘制在窗体画布上
                windowG.DrawImage(tempBmp,0,0);

                Thread.Sleep(sleepTime);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }


        //创建监听键盘按下和抬起的方法,此处调用GameManager中的方法
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
