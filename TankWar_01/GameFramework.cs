using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankWar_01
{
    class GameFramework
    {
        public static Graphics g;

        public static void Start()
        {
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMytank();
            
        }

        public static void Update()
        {
           
            GameObjectManager.Update();
        }

       
    }
}
