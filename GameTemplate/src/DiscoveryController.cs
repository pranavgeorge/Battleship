﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;
using static MyGame.UtilityFunctions;
using static MyGame.GameController;

namespace MyGame
{
    /// <summary>
    /// The battle phase is handled by the DiscoveryController.
    /// </summary>
    static class DiscoveryController
    {
       

        /// <summary>
        /// Handles input during the discovery phase of the game.
        /// </summary>
        /// <remarks>
        /// Escape opens the game menu. Clicking the mouse will
        /// attack a location.
        /// </remarks>
        public static void HandleDiscoveryInput()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                AddNewState(GameState.ViewingGameMenu);
            }

            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                DoAttack();
            }
        }

        /// <summary>
        /// Attack the location that the mouse if over.
        /// </summary>
        private static void DoAttack()
        {
            Point2D mouse = default(Point2D);

            mouse = SwinGame.MousePosition();

            //Calculate the row/col clicked
            int row = 0;
            int col = 0;
            row = Convert.ToInt32(Math.Floor((mouse.Y - FIELD_TOP) / (CELL_HEIGHT + CELL_GAP)));
            col = Convert.ToInt32(Math.Floor((mouse.X - FIELD_LEFT) / (CELL_WIDTH + CELL_GAP)));

            if (row >= 0 & row < HumanPlayer.EnemyGrid.Height)
            {
                if (col >= 0 & col < HumanPlayer.EnemyGrid.Width)
                {
                    Attack(row, col);
                }
            }
        }

        /// <summary>
        /// Draws the game during the attack phase.
        /// </summary>s
        public static void DrawDiscovery()
        {
            const int SCORES_LEFT = 172;
            const int SHOTS_TOP = 157;
            const int HITS_TOP = 206;
            const int SPLASH_TOP = 256;
            Rectangle toDraw = default(Rectangle);
            string Print = null;
            toDraw.X = 0;
            toDraw.Y = 250;
            toDraw.Width = SwinGame.ScreenWidth();
            toDraw.Height = SwinGame.ScreenHeight();
            if ((SwinGame.KeyDown(KeyCode.LeftShiftKey) | SwinGame.KeyDown(KeyCode.RightShiftKey)) & SwinGame.KeyDown(KeyCode.CKey))
            {
                DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, true);
                Print = "-- CHEATER --";

                SwinGame.DrawText(Print, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);

            }
            else
            {
                DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, false);
            }

            DrawSmallField(HumanPlayer.PlayerGrid, HumanPlayer);
            DrawMessage();

            SwinGame.DrawText(HumanPlayer.Shots.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
            SwinGame.DrawText(HumanPlayer.Hits.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, HITS_TOP);
            SwinGame.DrawText(HumanPlayer.Missed.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
        }

    }

}
