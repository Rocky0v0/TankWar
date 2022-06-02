using System;
using System.Collections.Generic;
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

        //5.在创建完包含了墙元素的地图后，将该地图最终绘制出来
        public static void DrawMap()
        {
            foreach(NotMoveThing nm in wallList)
            {
                //notmovething属于gameobject子类，gameobject中的DrawSelf()方法可以在此处使用
                nm.DrawSelf();
               //6.由于DrawMap()方法需要每帧实时刷新并检测，所以放在GameFramework.cs的Update方法中
            }
        }
        //4.添加创建地图方法，并在此方法中调用创建墙方法
        //6.2创建地图只需创建一次，所以在gameframework中的start方法中调用
        public static void CreateMap()
        {
            CreateWall(1, 1, 5);//,WallList);
            
        }


        //创建元素具体流程为->创建元素(CreateWall)->将元素放入地图(CreateMap)->绘制地图(DrawMap)

        //2.创建墙元素需要构造方法(不可移动元素的构造方法在NotMovething类中创建)
        //2.1临时创建墙元素方法：此方法为工具方法，声明为private因为只需要在上方CreateMap中调用
        private static void CreateWall(int x,int y,int count) //,List<NotMoveThing> wallList)
        {

            int xPosition = x * 30;
            int yPosition = y * 30;

            for(int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                //使用NotMoveTing中创建的构造函数
                //图片赋值时显示为null解决方法：在resources.resx中将访问修饰符改为public
                NotMoveThing wall1 = new NotMoveThing(xPosition, i, Resources.wall);
                NotMoveThing wall2 = new NotMoveThing(xPosition+15, i, Resources.wall);

                wallList.Add(wall1); //放入创建的walllist集合
                wallList.Add(wall2); //放入创建的walllist集合
            }
            
        }

    }
}
