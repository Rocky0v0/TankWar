using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar_01.Properties;

namespace TankWar_01
{
    enum Tag
    {
        MyTank,
        EnemyTank
    }
    class Bullet:MoveThing
    {
        public Tag Tag { get; set; }

        public Bullet(int x, int y, int speed,Direction dir,Tag tag)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = Resources.BulletDown;
            BitmapUp = Resources.BulletUp;
            BitmapLeft = Resources.BulletLeft ;
            BitmapRight = Resources.BulletRight;
            this.Dir = dir;
            this.Tag = tag;

            this.X-=Width/2;
            this.Y-=Height/2;
        }

        public override void DrawSelf()
        {
            base.DrawSelf();
        }








    }
}
