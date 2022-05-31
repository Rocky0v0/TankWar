using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWar_01
{
    class GameFramework
    {
        public static Graphics g;

        public static void Start()
        {
            GameObjectManager.CreateMap();
            
        }

        public static void Update()
        {
            GameObjectManager.DrawMap();
        }
    }
}
