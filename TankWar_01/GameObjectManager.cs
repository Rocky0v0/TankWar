using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWar_01.Properties;

namespace TankWar_01
{   
    //此类用于统一管理游戏元素

    class GameObjectManager
    {
        private static List<NotMoveThing> wallList = new List<NotMoveThing>();

        public static void DrawMap()
        {
            foreach(NotMoveThing nm in wallList)
            {
                nm.DrawSelf();
            }
        }

        public static void CreateMap()
        {
            CreateWall(1, 1, 5,wallList);
            
        }


        //临时创建墙元素
        private static void CreateWall(int x,int y,int count, List<NotMoveThing> wallList)
        {

            int xPosition = x * 30;
            int yPosition = y * 30;

            for(int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                //使用NotMoveTing中创建的构造函数
                NotMoveThing wall1 = new NotMoveThing(xPosition, i, Resources.wall);
                NotMoveThing wall2 = new NotMoveThing(xPosition+15, i, Resources.wall);

                wallList.Add(wall1); //放入创建的集合
                wallList.Add(wall2); //放入创建的集合
            }
            
        }

    }
}
