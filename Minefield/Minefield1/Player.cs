using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield1
{
    class Player
    {
        string name;
        public int column;
        public int row;
        public List<Point> path = new List<Point>();
        public Image playerIcon;

        public const int SUBMARINE = 1;
        public const int TANK = 2;
        public const int SOLDIER = 3;

        /// <summary>
        /// Creates a new player object for the game
        /// </summary>
        /// <param name="name"> Name of the player </param>
        /// <param name="col"> Start position of player</param>
        /// <param name="row">Start position of player</param>
        /// <param name="icon">The icon code for the avatar</param>
        public Player(string name, int col, int row, int icon)
        {
            this.name = name;
            this.row = row;
            this.column = col;

            //set the player icon/image
            switch (icon)
            {
                case SUBMARINE:
                    this.playerIcon = Square.submarineIcon;
                    break;
                case SOLDIER:
                    this.playerIcon = Square.soldierIcon;
                    break;
                case TANK:
                    this.playerIcon = Square.tankIcon;
                    break;
            }
        }

        /// <summary>
        /// Shows the player in the spot given by the column and row variables
        /// </summary>
        /// <param name="squares"> Squares on which the player is to be shown </param>
        public void show(Square[,] squares)
        {
            squares[row, column].BackColor = Square.trailColor;
            squares[row, column].Image = playerIcon;
        }

        /// <summary>
        /// Hides the player in its current position
        /// </summary>
        /// <param name="squares"></param>
        public void hide(Square[,] squares)
        {
            squares[row, column].Image = null;//removes image
        }

        /// <summary>
        /// Changes the player icon to an explosion
        /// </summary>
        /// <param name="squares"></param>
        public void die(Square[,] squares)
        {
            savePath();
            squares[row, column].Image = Square.explosion;
        }

        /// <summary>
        /// Moves player up one square (checks if move is allowed first)
        /// </summary>
        /// <param name="squares"></param>
        public void moveUp(Square[,] squares)
        {
            int newRow = row - 1;

            if (newRow >= 0)//check if move is allowed
            {
                savePath();
                hide(squares);
                row = newRow;
                show(squares);
            }
        }


        /// <summary>
        /// moves player down one square (if move is within the bounds of the grid)
        /// </summary>
        /// <param name="squares"></param>
        public void moveDown(Square[,] squares)
        {
            int newRow = row + 1;

            if (newRow < squares.GetLength(0))//check move is allowed
            {
                savePath();
                hide(squares);
                row = newRow;
                show(squares);
            }
        }

        /// <summary>
        /// Moves player right one square (if move is within grid)
        /// </summary>
        /// <param name="squares"></param>
        public void moveRight(Square[,] squares)
        {
            int newCol = column + 1;

            if (newCol < squares.GetLength(0))//checks move is allowed
            {
                savePath();
                hide(squares);
                column = newCol;
                show(squares);
            }
        }

        /// <summary>
        /// moves player left one square (if this is within the bounds of the squares)
        /// </summary>
        /// <param name="squares"></param>
        public void moveLeft(Square[,] squares)
        {
            int newCol = column - 1;

            if (newCol >= 0)//checks this move is allowed
            {
                savePath();
                hide(squares);
                column = newCol;
                show(squares);
            }
        }

        /// <summary>
        /// Saves the path of the player through the board
        /// </summary>
        private void savePath()
        {
            path.Add(new Point(row, column));
        }

        public void hidePath(Square[,] squares)
        {
            foreach(Point p in path)
            {
                squares[p.X, p.Y].BackColor = Square.nonBombRevealColor;
            }

            squares[path[path.Count - 1].X, path[path.Count - 1].Y].Image = Square.bomb;

        }

        /// <summary>
        /// Checks for the number of bombs around the player on the squares
        /// </summary>
        /// <param name="squares"> the grid the player is on </param>
        /// <returns></returns>
        public int checkBombs(Square[,] squares)
        {
            int bombs = 0;

            if (row - 1 >= 0 && squares[row-1,column].isBomb)bombs++;//in front
            if (row + 1 < squares.GetLength(0) && squares[row + 1, column].isBomb) bombs++;//below
            if (column - 1 >= 0 && squares[row, column - 1].isBomb) bombs++;//to the left
            if (column + 1 < squares.GetLength(0) && squares[row, column + 1].isBomb) bombs++;//to the right

            return bombs;
        }

        /// <summary>
        /// Checks if the square the player is on is a bomb
        /// </summary>
        /// <param name="squares"></param>
        /// <returns></returns>
        public bool onBomb(Square[,] squares)
        {
            if (squares[row, column].isBomb) return true;
            else return false;
        }

        /// <summary>
        /// Checks if the player is on the end square 
        /// </summary>
        /// <param name="squares">the squares the player is on</param>
        /// <param name="endRow"> the end row number marker of the end point</param>
        /// <param name="endCol">end column number of the end point</param>
        /// <returns></returns>
        public bool onEnd(Square[,] squares, int endRow, int endCol)
        {
            if (row == endRow && column == endCol) return true;
            else return false;
        }


    }
}
