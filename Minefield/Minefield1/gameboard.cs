using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minefield1
{
    /// <summary>
    /// Class containing the methods and variables for a minefield game
    /// </summary>
    class Gameboard
    {
        public Player player;//player on the board
        Square[,] squares;//squares making up the board        
        Panel panel;//panel that the board is to be on
        int endCol;//column number of the end marker
        int gridSize;//size of the board
        Timer peekTimer;
        Timer replayTimer;
        const int REPLAY_DELAY = 200;//milliseconds between moves in replay mode
        int replayCounter = 0;

        //store the game state
        public bool gameOver = false;
        public bool win = false;

        /// <summary>
        /// Creates a new game board with squares and a player
        /// </summary>
        /// <param name="gridSize"></param>
        /// <param name="bombDensity"></param>
        /// <param name="panel"></param>
        /// <param name="playerName"></param>
        public Gameboard(int gridSize, int bombDensity, Panel panel, string playerName, int avatarCode)
        {
            this.gridSize = gridSize;
            this.panel = panel;

            squares = new Square[gridSize, gridSize];
            player = new Player(playerName, gridSize/2, gridSize - 1, avatarCode);

            //Setup the style according to the avator chosen
            if(avatarCode == Player.SUBMARINE)
            {
                Square.defaultColor = Color.Blue;
                Square.trailColor = Color.White;
            }
            else
            {
                Square.defaultColor = Color.GreenYellow;
                Square.trailColor = Color.SandyBrown;
            }

            squares = setupSquares(gridSize, bombDensity);//setup squares, bombs, player and end marker      
        }

        /// <summary>
        /// Sets up the squares on the panel
        /// </summary>
        /// <param name="density"></param>
        public Square[,] setupSquares(int gridSize,int density)
        {
            Square[,] squares = new Square[gridSize, gridSize];

            Random random = new Random();
            int num;//stores the random number

            bool bomb = false;

            //pixel positions of the current label
            int x = 0;
            int y = 0;

            //go through each label and initialise it
            for(int i = 0; i < gridSize; i++)
            {
                x = 0;//start at the start of each row
                for(int j = 0; j < gridSize; j++)
                {
                    //decide if the square is a bomb
                    num = random.Next(0, 101);
                    if (num < density && i != 0 && i != gridSize - 1) bomb = true;//makes sure no bombs on top and bottom line
                    else bomb = false;

                    squares[i, j] = new Square(bomb, x, y, panel);

                    //used for debugging - shows bombs
                    //if (bomb)squares[i, j].Image = Square.bomb;

                    x += Square.SIZE;//move along the row
                }

                y += Square.SIZE;//move a row down
            }

            //chose the position of the end marker
            num = random.Next(0, gridSize);
            //show the end marker
            squares[0, num].BackColor = Color.White;
            squares[0, num].Image = Square.endMarker;
            //store the position of the end marker
            endCol = num;

            player.show(squares);

            return squares;
        }

        /// <summary>
        /// removes each square from the panal by calling the remove method in the square class
        /// </summary>
        public void removeSquares()
        {
            foreach(Square s in squares)
            {
                s.remove();
            }
        }

        /// <summary>
        /// Checks the number of bombs around the player
        /// </summary>
        /// <returns>the number of bombs</returns>
        public int checkBombs()
        {
            return player.checkBombs(squares);
        }

        /// <summary>
        /// Following methods are for moving the player
        /// </summary>
        public void movePlayerUp()
        {
            player.moveUp(squares);
        }
        public void movePlayerDown()
        {
            player.moveDown(squares);
        }
        public void movePlayerLeft()
        {
            player.moveLeft(squares);
        }
        public void movePlayerRight()
        {
            player.moveRight(squares);
        }

        /// <summary>
        /// Checks if the player has moved onto a bomb or the end marker 
        /// </summary>
        public void update()
        {
            //check if on bomb
            if (player.onBomb(squares))
            {
                gameOver = true;
                win = false;
            }
            if (player.onEnd(squares, 0, endCol))
            {
                gameOver = true;
                win = true;
            }
        }

        /// <summary>
        /// Shows all the bombs on the gameboard
        /// </summary>
        public void showBombs()
        {
            foreach(Square s in squares)
            {
                if(s.BackColor != Square.trailColor) s.BackColor = Square.nonBombRevealColor;
                if (s.isBomb) s.Image = Square.bomb;
            }

            player.show(squares);//stops it from overwriting the player image
        }

        /// <summary>
        /// Removes all the bomb icons from the squares 
        /// </summary>
        public void hideBombs()
        {
            foreach (Square s in squares)
            {
                 if(s.BackColor != Square.trailColor) s.BackColor = Square.defaultColor;
                if (s.isBomb) s.Image = null;
            }

            player.show(squares);//stops it from overwriting the player image
        }

        /// <summary>
        /// Calls a method to change the player icon to an exomplosion image
        /// </summary>
        public void killPlayer()
        {
            this.player.die(this.squares);
        }

        /// <summary>
        /// Makes the player icon move along the path it took in the game
        /// </summary>
        public void replay()
        { 
            player.hidePath(squares);//remove it so it can be redone
            
            //starts the timer whose tick method incrementally reveals the path
            replayTimer = new Timer();
            replayTimer.Interval = REPLAY_DELAY;
            replayTimer.Tick += new System.EventHandler(replayTimer_Tick);
            replayTimer.Enabled = true;            
        }

        /// <summary>
        /// Starts a timer and shows the bombs
        /// When the timer ticks it hides the bombs again
        /// </summary>
        /// <param name="peekTime"></param>
        public void peekBombs(int peekTime)
        {
            peekTimer = new Timer();
            peekTimer.Interval = peekTime;
            peekTimer.Tick += new System.EventHandler(peekTimer_Tick);
            peekTimer.Start();
            showBombs();
            //when the timer ticks bombs will be hidden and the timer will stop
        }

        /// <summary>
        /// Hides bombs and stops the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peekTimer_Tick(object sender, EventArgs e)
        {
            hideBombs();
            peekTimer.Enabled = false;
        }

        /// <summary>
        /// Moves the player on one more square 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replayTimer_Tick(object sender, EventArgs e)
        {
            
            if (replayCounter != 0)player.hide(squares);//for moving a player
            player.column = player.path[replayCounter].Y;
            player.row = player.path[replayCounter].X;
            player.show(squares);//show at the new square
            replayCounter++;

            //end replay
            if(replayCounter >= player.path.Count)
            {
                player.die(squares);
                replayTimer.Enabled = false;
            }
        }


    }
}
