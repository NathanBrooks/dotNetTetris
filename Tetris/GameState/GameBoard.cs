﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Tetris.GameState
{
    class GameBoard
    {
        public static int SizeX = 10;
        public static int SizeY = 18;
        private int[,] Board;

        Canvas GameCanvas;

        ArrayList Rectangles = new ArrayList();

        public GameBoard(ref Canvas gameCanvas)
        {
            this.GameCanvas = gameCanvas;
            Board = new int[SizeY, SizeX];
        }

        public int this[int i, int j]
        {
            get { return Board[i, j]; }
            set { Board[i, j] = value; }
        }

        public int clearRows()
        {
            reDraw();
            return 0;
        }

        private void reDraw()
        {
            foreach (Rectangle rect in Rectangles)
            {
                GameCanvas.Children.Remove(rect);
            }

            for (int y=0; y<SizeY; y++)
            {
                for(int x=0; x<SizeX; x++)
                {
                    if(Board[y,x] != 0)
                    {
                        Rectangle rect = new Rectangle() { Height = TetrisGameManager.BlockHeight, Width = TetrisGameManager.BlockWidth };
                        Canvas.SetTop(rect, (TetrisGameManager.BlockHeight * y));
                        Canvas.SetLeft(rect, (TetrisGameManager.BlockHeight * x));
                        rect.Fill = TetrisGameManager.ShapeColors[Board[y, x] - 1];

                        Rectangles.Add(rect);
                        GameCanvas.Children.Add(rect);
                    }
                }
            }
        }
    }
}
