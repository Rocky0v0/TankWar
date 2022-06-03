using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //5.在创建完包含了墙元素的地图后，将该地图最终绘制出来
        public static void DrawMap()
        {
            foreach(NotMoveThing nm in wallList)
            {
                //notmovething属于gameobject子类，gameobject中的DrawSelf()方法可以在此处使用
                nm.DrawSelf();
               //6.由于DrawMap()方法需要每帧实时刷新并检测，所以放在GameFramework.cs的Update方法中
            }

            foreach (NotMoveThing nm in steelList)
            {
              
                nm.DrawSelf();
                
            }
            //直接调用boss元素的drawself方法绘制
            Boss.DrawSelf();
        }

        //创建方法绘制MyTank
        public static void DrawMyTank()
        {
            myTank.DrawSelf();
        }

        
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

    }
}
            

           




