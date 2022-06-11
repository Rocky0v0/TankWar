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
    enum GameState{
        Running,
        Gameover
    }
    class GameFramework
    {
        private static GameState gameState = GameState.Running;
        public static Graphics g;

        public static void Start()
        {
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMytank();
            
        }

        public static void Update()
        {
           
            
            if(gameState == GameState.Running)
            {
                GameObjectManager.Update();
            }else if(gameState == GameState.Gameover)
            {
                GameOverUpdate();
            }

           
        }
        private static void GameOverUpdate()
        {
            int x = 450 / 2 - Properties.Resources.GameOver.Width / 2;
            int y = 450 / 2 - Properties.Resources.GameOver.Height / 2;
            g.DrawImage(Resources.GameOver, x, y);
        }
        public static void ChangeToGameOver()
        {
            gameState = GameState.Gameover;
        }


    }
}
