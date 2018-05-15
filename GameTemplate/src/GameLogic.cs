using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;
using static MyGame.GameResources;
using static MyGame.GameController;
using System.Security;
using System.Runtime.ExceptionServices;

namespace MyGame
{
    
    static class GameLogic
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public static void Main()
        {
            //Opens a new Graphics Window
            SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

            //Load Resources
            LoadResources();

            SwinGame.PlayMusic(GameMusic("Background"));

            //Game Loop
            do
            {
                HandleUserInput();
                DrawScreen();
            } while (!(SwinGame.WindowCloseRequested() == true | CurrentState == GameState.Quitting));

            SwinGame.StopMusic();

            //Free Resources and Close Audio, to end the program.
            try
            {
                FreeResources();
            }
            catch (Exception e)
            // We could be catching anything here 
            {
                // The exception we caught could have been a program error
                // or something much more serious. Regardless, we know that
                // something is not right. We'll just output the exception 
                // and exit with an error. We won't try to do any work when
                // the program or process is in an unknown state!

                System.Console.WriteLine(e.Message);
            }

        }
    }
}
