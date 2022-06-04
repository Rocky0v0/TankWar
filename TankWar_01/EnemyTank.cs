using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar_01
{
    class EnemyTank:MoveThing
    {
        Random r = new Random();

        public EnemyTank(int x, int y, int speed,Bitmap bmpDown,Bitmap bmpUp,Bitmap bmpRight,Bitmap bmpLeft)
        {
            
            this.X = x;
            this.Y = y;
            this.Speed = speed;

            //坦克的四个方向图片是固定的，直接在构造方法中写
            //传递Movething中的四个方向的set属性
            BitmapDown = bmpDown;
            BitmapUp = bmpUp;
            BitmapLeft = bmpLeft;
            BitmapRight = bmpRight;

            //默认朝向：可以按照默认值赋值
            this.Dir = Direction.Down;
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
                if (Y - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    ChangeDirection();
                    return;
                }
            }


            //碰撞检测(判断图片四个角的点是否与另外一个元素的四个角重合)系统提供了用于长方体碰撞检测的方法

            //需要使用未来的位置进行碰撞检测，如果拿现在的位置进行检测，碰到墙后isMoving就一直为false无法移动
            Rectangle rect = GetRectangle();

            //判断将要移动的方位
            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;

            }
            if (GameObjectManager.IsCollidedWall(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                ChangeDirection();
                return;
            }


        }
        //创建随机改变敌人朝向方法
        private void ChangeDirection()
        {
            //改变敌人朝向时不能和当前朝向保持一致
            while (true)
            {
                Direction dir = (Direction)r.Next(0, 4);//生成随机方向

                if(dir == Dir)
                {
                    continue;
                }
                else
                {
                    Dir = dir;
                    break;
                }

            }

            MoveCheck();
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

    }
}
