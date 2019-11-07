using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minefield1
{
    /// <summary>
    /// Class contining the methods to create a form for a game and run that game
    /// </summary>
    public partial class MainForm : Form
    {
        //Declarations******************************************************************
        Gameboard gameboard;
        string playerName;
        int time = 0;
        bool firstMove = true;//used to know if the timer should be started

        enum Direction { up, down, left, right };
        const int PANEL_MARGINS = 20;//used to give the thickness of the border that appears around the game panel
        //******************************************************************************

        /// <summary>
        /// Sets up a new form for playing the game
        /// </summary>
        /// <param name="playerName"> the chosen name of the current player</param>
        public MainForm(string playerName)
        {
            this.playerName = playerName;

            InitializeComponent();

            this.Text = "Hello, " + playerName;
        }

        /// <summary>
        /// Sets up the first game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            setupGame();
        }

        /// <summary>
        /// sets up the gameboard and timer
        /// </summary>
        private void setupGame()
        {
            //show the previous scores for this game setup
            showScores();
            //set up gamebaord
            setupPanels();
            //update bomb number
            update();
        }

        /// <summary>
        /// Calls methods to setup gameboard and bomb indicator panels
        /// </summary>
        private void setupPanels()
        {
            setupGameboard();
            setupBombPanel();//sets up the bomb indicator panel so it is the correct size
        }

        /// <summary>
        /// Sets up the bomb indicator panel
        /// </summary>
        private void setupBombPanel()
        {
            int size = gamePanel.Height + PANEL_MARGINS;//means it is just bigger than the game panel

            bombIndicatorPanel.Size = new Size(size, size);
            bombIndicatorPanel.Location = new Point(background.Width / 2 - size / 2, background.Height / 2 - size / 2);
        }

        /// <summary>
        /// Sets up a new gameboard and game panel
        /// </summary>
        private void setupGameboard()
        {
            int density = (int)bombDensity.Value;
            int size = (int)gridSize.Value;
            int panelSize = size * Square.SIZE;

            //setup the game panel
            gamePanel.Size = new Size(panelSize, panelSize);
            gamePanel.Location = new Point(background.Width / 2 - panelSize / 2, background.Height / 2 - panelSize / 2);

            //create gamboard on panel
            gameboard = new Gameboard(size, density, gamePanel, playerName, getIconCode());

            gameboard.peekBombs((size + density) * 50);//allows the user to view the bombs for a time proportional to the difficulty
        }

        /// <summary>
        /// Works out which icon is selected and returns the appropriate icon code
        /// </summary>
        /// <returns> the icon code of the selected icon</returns>
        private int getIconCode()
        {
            if (submarineBtn.Checked) return Player.SUBMARINE;
            if (soldierBtn.Checked) return Player.SOLDIER;
            else return Player.TANK;//defualt
        }

        /// <summary>
        /// Displays the previous scores for the current game mode
        /// </summary>
        private void showScores()
        {
            scoresBox.Items.Clear();//remove current items
            scoresBox.Items.AddRange(Scores.getScores(gridSize.Value, bombDensity.Value).ToArray());//show scores for this games setup
        }

        /// <summary>
        /// resets the gameboard calls method to redo the gameboard etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetBtn_Click(object sender, EventArgs e)
        {
            //reset timers
            time = 0;
            timeLbl.Text = "0s";
            gameTimer.Enabled = false;

            firstMove = true;//so form knows to start on first move

            gameboard.removeSquares();//remove the old squares

            setupGame();//setup the new game
        }

        /// <summary>
        /// calls method to move player up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            movePlayer(Direction.up);
        }

        /// <summary>
        /// calls method to move player down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            movePlayer(Direction.down);
        }

        /// <summary>
        /// calls method to move player right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightBtn_Click(object sender, EventArgs e)
        {
            movePlayer(Direction.right);
        }

        /// <summary>
        /// Calls method to move left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftBtn_Click(object sender, EventArgs e)
        {
            movePlayer(Direction.left);
        }

        /// <summary>
        /// Allows navigation with arrow keys and WASD
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.W)
            {
                movePlayer(Direction.up);
                return true;
            }
            if (keyData == Keys.Down || keyData == Keys.S)
            {
                movePlayer(Direction.down);
                return true;
            }
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                movePlayer(Direction.left);
                return true;
            }
            if (keyData == Keys.Right || keyData == Keys.D)
            {
                movePlayer(Direction.right);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// moves player in the direction input
        /// </summary>
        /// <param name="direction">the direction to move in</param>
        private void movePlayer(Direction direction)
        {
            if (gameboard.gameOver == false)//only move if game is still running
            {
                //timer starts if this is the is the first move
                if (firstMove == true)
                {
                    //MessageBox.Show("Starting timer");
                    firstMove = false;
                    gameTimer.Start();
                }

                //decide which direction to go in
                switch (direction)
                {
                    case Direction.up:
                        gameboard.movePlayerUp();
                        break;
                    case Direction.down:
                        gameboard.movePlayerDown();
                        break;
                    case Direction.left:
                        gameboard.movePlayerLeft();
                        break;
                    case Direction.right:
                        gameboard.movePlayerRight();
                        break;
                }

                update();//show bomb num, check win/lose
            }
        }

        /// <summary>
        /// Shows the number of bombs nearby and checks for win and lose
        /// Calls appropriate methods if there is a win or lose
        /// </summary>
        private void update()
        {

            updateBombIndicators(gameboard.checkBombs());//shows the number of bombs
            
            gameboard.update();//this method checks for win/lose

            if (gameboard.gameOver)//if game is ended
            {
                endGame();
            }

        }

        /// <summary>
        /// Shows the number of bombs on the label and changes the  back color to reflect this
        /// </summary>
        /// <param name="bombs"></param>
        private void updateBombIndicators(int bombs)
        {
            bombLbl.Text = bombs.ToString();//show the nearby bombs

            if (bombs == 0)
            {
                bombLbl.BackColor = Color.LightGreen;
                bombIndicatorPanel.BackColor = Color.LightGray;
            }
            if (bombs == 1)
            {
                bombLbl.BackColor = Color.Yellow;
                bombIndicatorPanel.BackColor = Color.Yellow;
            }
            if (bombs > 1)
            {
                bombLbl.BackColor = Color.Salmon;
                bombIndicatorPanel.BackColor = Color.Salmon;
            }
        }

        /// <summary>
        /// Method to be called when the game has ended - determines if the player has won or lost
        /// and shows the appropriate messages etc
        /// </summary>
        private void endGame()
        {
            gameTimer.Enabled = false;

            //lose stuff
            if (!gameboard.win)
            {
                gameboard.killPlayer();
                gameboard.showBombs();
                gameboard.replay();

                bombIndicatorPanel.BackColor = Color.Red;

                MessageBox.Show("You Lost!!! - press RESET to start again");
            }
            //win stuff
            else
            {
                //tell the player if they beat the old high score
                if (time < Scores.getHighScore(gridSize.Value, bombDensity.Value))
                {
                    MessageBox.Show("YOU BEAT THE OLD HIGH SCORE by " + (Scores.getHighScore(gridSize.Value, bombDensity.Value) - time) + "s !!!");
                }

                //option to save score
                if (MessageBox.Show("Completed in " + time + "s -  Would you like to save score?", $"Well done {playerName}!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Scores.saveScore(playerName, time, gridSize.Value, bombDensity.Value);
                }

                bombIndicatorPanel.BackColor = Color.GreenYellow;
                gameboard.showBombs();

            }
        }

        /// <summary>
        /// updates the time on the time label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            time++;
            timeLbl.Text = time.ToString() + "s";
        }

        /// <summary>
        /// Shows a dialog explaining how to play the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            string lineBreak = Environment.NewLine + "--------------------------------------------------------------------------------------------" + Environment.NewLine;
            MessageBox.Show(lineBreak + "Use the arrow button or arrow keys or WASD keys to navigate the tank to the location marker" + lineBreak +
                "Avoid hitting bombs by using the bomb counter or game border to work out if there might be a bomb in front" + lineBreak +
                "Settings - Use the grid-size and bomb-density settings to change the difficulty - press RESET to enact the changes" + lineBreak +
                "Try and beat the scores shown on the score box. Save your score if you want. " + lineBreak +
                "Use the Beat High Score button to try and beat the current high score for your chosen settings" + lineBreak, "HELP:");
        }
    }
}
