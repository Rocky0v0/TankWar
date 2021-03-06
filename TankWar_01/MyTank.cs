using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankWar_01.Properties;

namespace TankWar_01
{
    class MyTank:MoveThing
    {
        //创建布尔成员判断坦克是否在移动
        public bool IsMoving { get; set; }
        public int HP { get; set; }
        //出生点
        private int originalX;
        private int originalY;

        //创建构造方法
        //1.传递GameObject中的参数 x y
        //2.传递MoveThing中的参数speed speed为一帧移动多少像素的速度
        public MyTank(int x,int y,int speed)
        {
            IsMoving = false;
            originalX = x;
            originalY = y;
            this.X = x;
            this.Y = y;
            this.Speed = speed;

            //坦克的四个方向图片是固定的，直接在构造方法中写
            //传递Movething中的四个方向的set属性
            BitmapDown = Resources.MyTankDown;
            BitmapUp = Resources.MyTankUp;
            BitmapLeft = Resources.MyTankLeft;
            BitmapRight = Resources.MyTankRight;

            //默认朝向：可以按照默认值赋值
            this.Dir = Direction.Up;
            HP = 4;

       

        }

        //通过窗体事件调用Gamemanager中的方法，通过Gamemanager中的方法调用mytank中的方法
        //并在mytank中处理事件的按下和抬起
        public void KeyDown(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    Dir = Direction.Up;
                    IsMoving = true;
                    break;
                case Keys.S:
                    Dir = Direction.Down;
                    IsMoving = true;
                    break;
                case Keys.D:
                    Dir = Direction.Right;
                    IsMoving = true;
                    break;
                case Keys.A:
                    Dir = Direction.Left;
                    IsMoving = true;
                    break;
                case Keys.Space:
                    Attack();
                    break;
            }
        }
        private void Attack() {
            //发射子弹
            //发射音效
            SoundManager.PlayFire();
            //在gameobjectmanager中创建子弹
            //调用创建子弹
            int x = this.X;
            int y = this.Y;
            //通过方向计算子弹位置
            switch (Dir)
            {
                case Direction.Up:
                    x = x + Width / 2;
                    break;
                case Direction.Down:
                    x = x + Width / 2;
                    y += Height;
                    break;
                case Direction.Left:
                    y = y + Height / 2;
                    break;
                case Direction.Right:
                    x += Width;
                    y = y + Height / 2;
                    break;


            }
            GameObjectManager.CreateBullet(x, y, Tag.MyTank, Dir);
        }

        public void KeyUp(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    
                    IsMoving = false;
                    break;
                case Keys.S:
                  
                    IsMoving = false;
                    break;
                case Keys.D:
                 
                    IsMoving = false;
                    break;
                case Keys.A:
                
                    IsMoving = false;
                    break;
            }

        }
        //受到伤害减少生命代码
        public void TakeDamage()
        {
            HP--;
            if(HP <= 0)
            {
                X = originalX;
                Y = originalY;
                HP = 4;
            }

        }

        //坦克移动在Update中实现，使坦克的移动更加流畅
        //需要将update方法传递到每个游戏元素中并在游戏元素中调用update方法

        //在Mytank中重写Update方法用于移动

        public override void Update()
        {

            MoveCheck(); //添加movecheck方法控制坦克不超出边界
            Move();
            base.Update();
        }

        public void MoveCheck()
        { 
            //检查是否超出窗体边界

            if(Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    IsMoving = false;
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
            if (GameObjectManager.IsCollidedWall(rect)!=null)
            {
                IsMoving=false;
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                IsMoving = false;
                return;
            }


        }

        private void Move()
        {
            if(IsMoving == false)
            {
                return;
            }
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
