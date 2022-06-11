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
    //1.创建类:此类用于统一管理游戏元素

    class GameObjectManager
    {
        //3.创建List集合用于放置墙元素方便之后统一绘制
        private static List<NotMoveThing> wallList = new List<NotMoveThing>();
        //创建新的List集合用于存放钢墙
        private static List<NotMoveThing> steelList = new List<NotMoveThing>();
        //构造boss，由于只有一个元素，所以不需要创建list保存
        private static NotMoveThing Boss;

        private static MyTank myTank;

        //创建集合管理敌人坦克
        private static List<EnemyTank> tankList = new List<EnemyTank>();

        //创建集合管理子弹
        private static List<Bullet> bulletList = new List<Bullet>();

        //创建集合管理爆炸效果
        private static List<Explosion> expList  = new List<Explosion>();

        //生成敌人代码需要持续生成
        //创建生成速度，以帧为单位生成
        private static int enemyBornSpeed = 60; //1秒生成一个
        private static int enemyBornCount = 60; //计数器，计数器为60的时候生成一个，游戏开始直接生成一个所以初始值为60
        
        //创建数组用于存放3个生成位置 使用Point：winform中的一个类，用于保存坐标，point是一个结构体
        private static Point[] points = new Point[3];
        
        //创建start方法用于在游戏开始时只调用一次*敌人出生点
        public static void Start()
        {
            //生成敌人有3个位置，每个位置随机生成4种敌人中的一种
            //1号位置
            points[0].X = 0; points[0].Y = 0;
            //2号位置
            points[1].X = 7*30; points[1].Y = 0;
            //3号位置
            points[2].X = 14 * 30; points[2].Y = 0;
        }
        public static void Update()
        {
            foreach (NotMoveThing nm in wallList)
            {
                //notmovething属于gameobject子类，gameobject中的DrawSelf()方法可以在此处使用
                nm.Update();
                //6.由于DrawMap()方法需要每帧实时刷新并检测，所以放在GameFramework.cs的Update方法中
            }

            foreach (NotMoveThing nm in steelList)
            {

                nm.Update();

            }
            //直接调用boss元素的drawself方法绘制
            Boss.Update();
            myTank.Update();

            //调用敌人生成方法
            EnemyBorn();

            //绘制敌人坦克
            foreach(EnemyTank tank in tankList)
            {
                tank.Update();
            }

            CheckAndRemoveBullet();
            CheckAndRemovExplosion();

            foreach (Bullet bullet in bulletList)
            {
                bullet.Update();
            }
            //添加绘制方法
            foreach(Explosion exp in expList)
            {
                exp.Update();
            }
            

        }

        //子弹生成
        public static void CreateBullet(int x,int y,Tag tag,Direction dir)
        {
            Bullet bullet = new Bullet(x, y, 5, dir, tag);
            bulletList.Add(bullet);
        }

        //检测子弹移除
        private static void CheckAndRemoveBullet()
        {
            List<Bullet> needToRemove = new List<Bullet>();
            foreach(Bullet bullet in bulletList)
            {
                if(bullet.IsRemove == true)
                {
                    needToRemove.Add(bullet);
                }
            }

            foreach(Bullet bullet in needToRemove)
            {
                bulletList.Remove(bullet);
            }
        }

        //检测爆炸效果移除
        private static void CheckAndRemovExplosion()
        {
            List<Explosion> needToRemove = new List<Explosion>();
            foreach (Explosion exp in expList)
            {
                if (exp.IsNeedDestroy ==true)
                {
                    needToRemove.Add(exp);
                }
            }

            foreach (Explosion exp in needToRemove)
            {
                expList.Remove(exp);
            }
        }
        //墙销毁方法

        public static void RemoveWall(NotMoveThing wall)
        {
            wallList.Remove(wall);
        }

        //坦克销毁方法
        public static void RemoveTank(EnemyTank tank)
        {
            tankList.Remove(tank);
        }

        public static void CreateExplosion(int x,int y)
        {
            Explosion exp = new Explosion(x, y);
            expList.Add(exp);
        }


       
        //添加敌人生成方法
        private static void EnemyBorn()
        {
            enemyBornCount++;
            if (enemyBornCount < enemyBornSpeed)
            {
                return;//如果计数器小于60则没到生成敌人时间，直接返回
            }
            else
            {
                //生成敌人代码

                //随机生成0-2中的数字代表敌人随机从三个刷新点的一个位置中生成
                Random rd = new Random();
                int index = rd.Next(0, 3);//随机生成0-3中的数字，不包含3
                Point position = points[index];
                //随机生成四种中的一种敌人
                int enemyType = rd.Next(1, 5);//随机生成1-4个敌人中的一个
                switch (enemyType)
                {
                    case 1:
                        CreateEnemyTank1(position.X, position.Y);
                        break;
                    case 2:
                        CreateEnemyTank2(position.X, position.Y);
                        break;
                    case 3:
                        CreateEnemyTank3(position.X, position.Y);
                        break;
                    case 4:
                        CreateEnemyTank4(position.X, position.Y);
                        break;

                }

                //生成时计数器归零
                enemyBornCount = 0;
            }
        }

        //创建生成敌人坦克方法->并在EnemyTank中提供构造方法用于构造坦克
        private static void CreateEnemyTank1(int x,int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GrayDown, Resources.GrayUp, Resources.GrayRight, Resources.GrayLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank2(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GreenDown, Resources.GreenUp, Resources.GreenRight, Resources.GreenLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank3(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 4, Resources.QuickDown, Resources.QuickUp, Resources.QuickRight, Resources.QuickLeft);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank4(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 1, Resources.SlowDown, Resources.SlowUp, Resources.SlowRight, Resources.SlowLeft);
            tankList.Add(tank);
        }

        //红砖墙碰撞
        public static NotMoveThing IsCollidedWall(Rectangle rt)
        {
            foreach(NotMoveThing wall in wallList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }

            }
                return null;
        }


        //钢墙碰撞
        public static NotMoveThing IsCollidedSteel(Rectangle rt)
        {
            foreach (NotMoveThing wall in steelList)
            {
                if (wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }

            }
            return null;
        }
        
        //Boss碰撞
        public static bool IsCollidedBoss(Rectangle rt)
        {
            return Boss.GetRectangle().IntersectsWith(rt);
            
        }

        //Mytank子弹碰撞敌人坦克
         public static EnemyTank IsCollidedEnemyTank(Rectangle rt)
        {
            foreach(EnemyTank tank in tankList)
            {
                if (tank.GetRectangle().IntersectsWith(rt))
                {
                    return tank;
                }
            }
            return null;
        }

        //EnemyTank子弹和Mytank碰撞
        public static MyTank IsCollidedMyTank(Rectangle rt)
        {
            if( myTank.GetRectangle().IntersectsWith(rt))return myTank;
            else return null;
        }


        //5.在创建完包含了墙元素的地图后，将该地图最终绘制出来
        //public static void DrawMap()
        //{
        //    foreach(NotMoveThing nm in wallList)
        //    {
        //        //notmovething属于gameobject子类，gameobject中的DrawSelf()方法可以在此处使用
        //        nm.DrawSelf();
        //       //6.由于DrawMap()方法需要每帧实时刷新并检测，所以放在GameFramework.cs的Update方法中
        //    }

        //    foreach (NotMoveThing nm in steelList)
        //    {

        //        nm.DrawSelf();

        //    }
        //    //直接调用boss元素的drawself方法绘制
        //    Boss.DrawSelf();
        //}

        ////创建方法绘制MyTank
        //public static void DrawMyTank()
        //{
        //    myTank.DrawSelf();
        //}


        //4.添加创建地图方法，并在此方法中调用创建墙方法
        //6.2创建地图只需创建一次，所以在gameframework中的start方法中调用
        public static void CreateMap()
        {
            CreateWall(1, 1, 5, Resources.wall, wallList);
            CreateWall(3, 1, 5, Resources.wall, wallList);
            CreateWall(5, 1, 4, Resources.wall, wallList);
            CreateWall(7, 1, 3, Resources.wall, wallList);
            CreateWall(9, 1, 4, Resources.wall, wallList);
            CreateWall(11, 1, 5, Resources.wall, wallList);
            CreateWall(13, 1, 5, Resources.wall, wallList);

            CreateWall(2, 7, 1, Resources.wall, wallList);
            CreateWall(3, 7, 1, Resources.wall, wallList);
            CreateWall(4, 7, 1, Resources.wall, wallList);
            CreateWall(6, 7, 1, Resources.wall, wallList);
            CreateWall(7, 6, 2, Resources.wall, wallList);
            CreateWall(8, 7, 1, Resources.wall, wallList);
            CreateWall(10, 7, 1, Resources.wall, wallList);
            CreateWall(11, 7, 1, Resources.wall, wallList);
            CreateWall(12, 7, 1, Resources.wall, wallList);

            CreateWall(1, 9, 5, Resources.wall, wallList);
            CreateWall(3, 9, 5, Resources.wall, wallList);
            CreateWall(5, 9, 3, Resources.wall, wallList);

            CreateWall(6, 10, 1, Resources.wall, wallList);
            CreateWall(7, 10, 2, Resources.wall, wallList);
            CreateWall(8, 10, 1, Resources.wall, wallList);

            CreateWall(9, 9, 3, Resources.wall, wallList);
            CreateWall(11, 9, 5, Resources.wall, wallList);
            CreateWall(13, 9, 5, Resources.wall, wallList);

            CreateWall(6, 13, 2, Resources.wall, wallList);
            CreateWall(7, 13, 1, Resources.wall, wallList);
            CreateWall(8, 13, 2, Resources.wall, wallList);

            //钢墙:不同墙体使用不同的集合list管理
            CreateWall(7, 5, 1, Resources.steel, steelList);
            CreateWall(0, 7, 1, Resources.steel, steelList);
            CreateWall(14, 7, 1, Resources.steel, steelList);

            //Boss元素直接使用CreateBoss创建
            CreateBoss(7, 14, Resources.Boss);

        }

        //创建元素具体流程为->创建元素(CreateWall)->将元素放入地图(CreateMap)->绘制地图(DrawMap)

        //2.创建墙元素需要构造方法(不可移动元素的构造方法在NotMovething类中创建)
        //2.1临时创建墙元素方法：此方法为工具方法，声明为private因为只需要在上方CreateMap中调用
        private static void CreateWall(int x,int y,int count, Image img,List<NotMoveThing> Listname)
        {

            int xPosition = x * 30;
            int yPosition = y * 30;

            for(int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                //使用NotMoveTing中创建的构造函数
                //图片赋值时显示为null解决方法：在resources.resx中将访问修饰符改为public
                NotMoveThing wall1 = new NotMoveThing(xPosition, i, img);
                NotMoveThing wall2 = new NotMoveThing(xPosition + 15, i, img);

                Listname.Add(wall1); //放入创建的对应的list集合
                Listname.Add(wall2); //放入创建的对应的list集合
            }
            
        }

        //创建boss
        private static void CreateBoss(int x,int y, Image img)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;

            Boss = new NotMoveThing(xPosition, yPosition,img);

        }

        //创建MyTank
        public static void CreateMytank()
        {
            //初始坐标
            int x = 5 * 30;
            int y = 14 * 30;

            //在movething中添加构造方法
            myTank = new MyTank(x, y, 2);


        }


        //将这两个事件传递给MyTank，所以要在MyTank中提供两个方法处理这两个事件
        public static void KeyDown(KeyEventArgs args)
        {
            myTank.KeyDown(args);
        }

        public static void KeyUp(KeyEventArgs args)
        {
            myTank.KeyUp(args);
        }

    }
}
            

           




