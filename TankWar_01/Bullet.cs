using System;
using System.Collections.Generic;
using System.Drawing;
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
    class Bullet : MoveThing
    {
        public Tag Tag { get; set; }

        public bool IsRemove { get; set; }

        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
            IsRemove = false;
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BitmapDown = Resources.BulletDown;
            BitmapUp = Resources.BulletUp;
            BitmapLeft = Resources.BulletLeft;
            BitmapRight = Resources.BulletRight;
            this.Dir = dir;
            this.Tag = tag;

            this.X -= Width / 2;
            this.Y -= Height / 2;
        }

        public override void DrawSelf()
        {
            base.DrawSelf();
        }

        public override void Update()
        {

            MoveCheck(); //添加movecheck方法控制坦克不超出边界
            Move();
            base.Update();
        }

        public void MoveCheck()
        {
            //检查是否超出窗体边界

            if (Dir == Direction.Up)
            {
                if (Y + Height / 2 + 3 < 0)
                {
                   IsRemove |= true;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Height / 2 - 3 > 450)
                {
                    IsRemove |= true;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X +Width/2-3 < 0)
                {
                    IsRemove |= true;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X +Width/2+3 > 450)
                {
                    IsRemove |= true;
                    return;
                }
            }


            //碰撞检测(判断图片四个角的点是否与另外一个元素的四个角重合)系统提供了用于长方体碰撞检测的方法

            //需要使用未来的位置进行碰撞检测，如果拿现在的位置进行检测，碰到墙后isMoving就一直为false无法移动
            Rectangle rect = GetRectangle();

            rect.X = X + Width / 2 - 3;
            rect.Y = Y + Height / 2 - 3;
            rect.Height = 3;
            rect.Width = 3;

            //检测子弹与墙，钢墙，坦克（敌人，主角）和Boss的碰撞
            int xExp = this.X+Width/2;
            int yExp = this.Y+Height/2;
            //墙
            NotMoveThing wall = null;
            if ((wall=GameObjectManager.IsCollidedWall(rect)) != null)
            {
                IsRemove = true;//子弹自身销毁
                //墙销毁 方法在GameObjectManager中建立
                GameObjectManager.RemoveWall(wall);
                GameObjectManager.CreateExplosion(xExp, yExp);
                return;
            }
            //钢墙
            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                IsRemove = true;
                GameObjectManager.CreateExplosion(xExp, yExp);
                return;
            }

           // if (GameObjectManager.IsCollidedBoss(rect))
           // {
             //  ChangeDirection();
             //  return;
           // }

            if(Tag == Tag.MyTank)
            {
                //MyTank 只需要判断是否与敌人发生碰撞 在GameObjectManager中添加方法
                EnemyTank tank = null;
                if ((tank = GameObjectManager.IsCollidedEnemyTank(rect)) != null)
                {
                    IsRemove = true;//自身销毁
                    GameObjectManager.CreateExplosion(xExp, yExp);
                    //坦克销毁方法在GameObjectManager中新建
                    GameObjectManager.RemoveTank(tank);
                    return;


                }
            }
        }
        private void Move()
        {

            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }







        private void ChangeDirection()
        {

        }
    }
}
