//using System;
//using SwinGameSDK;
//using static MyGame.GameResources;
//using static MyGame.GameController;
//using static SwinGameSDK.SwinGame; // requires mcs version 4+, 
//// using SwinGameSDK.SwinGame; // requires mcs version 4+, 

//namespace MyGame
//{
//    public class GameMain
//    {
//        public static void Main()
//        {
//            //Open the game window
//            OpenGraphicsWindow("Battle Ships", 800, 600);
//            ShowSwinGameSplashScreen();

//            //Load Resources
//            LoadResources();

//            SwinGame.PlayMusic("Background");
//            //Run the game loop
//            while(false == WindowCloseRequested())
//            {
//                //Fetch the next batch of UI interaction
//                ProcessEvents();
//                HandleUserInput();
//                DrawScreen();
//                //Clear the screen and draw the framerate
//                ClearScreen(Color.White);
//                DrawFramerate(0,0);
                
//                //Draw onto the screen
//                RefreshScreen(60);
//            }
//            SwinGame.StopMusic();
//            FreeResources();
//        }
//    }
//}
