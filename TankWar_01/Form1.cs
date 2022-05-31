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
        private Graphics g;


        public Form1()
        {
            
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            g = this.CreateGraphics();
            GameFramework.g = g;

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();

        }

        private static void GameMainThread()
        {
            GameFramework.Start();

            int sleepTime = 1000 / 60;

            while (true)
            {
                GameFramework.g.Clear(Color.Black);

                GameFramework.Update();

                Thread.Sleep(sleepTime);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
    }
}
