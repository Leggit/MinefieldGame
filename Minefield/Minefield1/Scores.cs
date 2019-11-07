using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Minefield1
{
    /// <summary>
    /// Class containing methods to store, retrieve and process scores from the scores file
    /// </summary>
    class Scores
    {
        //Records in this file are in the format name,time,gamecode
        const string SCORE_FILE = "scores.txt";

        /// <summary>
        ///Saves the users time to the file in the format:
        /// playerName,time,gridSizeBombDensity
        /// - the last field being a code made up of the two numbers appended onto each other
        /// <summary>
        /// <param name="playerName">name of the current player</param>
        /// <param name="time">the time they took</param>
        /// <param name="gridSize">the size of the grid played on</param>
        /// <param name="bombDensity"> the bomb density for the grid played on </param>
        public static void saveScore(string playerName, int time, decimal gridSize, decimal bombDensity)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(SCORE_FILE, true))
                {
                    sw.WriteLine(playerName + "," + time + "," + gridSize + bombDensity /*+Environment.NewLine/**/);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading scores from file");
            }
        }

        /// <summary>
        /// Gets the score records matching the game settings input
        /// Sorts them in order of fastest to slowest
        /// Returns them in a displayable format
        /// </summary>
        /// <param name="gridSize"></param>
        /// <param name="bombDensity"></param>
        /// <returns></returns>
        public static List<string> getScores(decimal gridSize, decimal bombDensity)
        {
            string gameCode = gridSize.ToString() + bombDensity.ToString();
            string line;
            List<string> scores = new List<string>();

            //get the data from the text file
            try
            {
                using (StreamReader sr = new StreamReader(SCORE_FILE))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        if (line.EndsWith(gameCode))//add the score record if it is for this game mode
                        {
                            scores.Add(line);
                        }
                    }
                }
            }catch(IOException ex)
            {
                MessageBox.Show("Error reading times from file");
            }

            scores = sortScores(scores);
            scores = getDisplayValues(scores);//removes the game codes for display            

            return scores;
        }

        /// <summary>
        /// Buble sorts the scores with the losest time being first and the slowest last
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        private static List<string> sortScores(List<string> scores)
        {
            bool swap = false;//used to know if the sort is complete

            char[] splitBy = { ','};//used to get the value that is used in comparisons
            
            //values used in the sort method to know if items should be swapped
            int currentValue;
            int compareTo;

            string temp;

            do
            {
                swap = false;//reset flag

                for(int i = 0; i < scores.Count - 1; i++)
                {
                    //get values to be compared
                    currentValue = Convert.ToInt32(scores[i].Split(splitBy)[1]);
                    compareTo = Convert.ToInt32(scores[i + 1].Split(splitBy)[1]);

                    if(currentValue > compareTo)
                    {
                        swap = true;//set flag 

                        //swap scores
                        temp = scores[i];
                        scores[i] = scores[i + 1];
                        scores[i + 1] = temp;
                    }
                }

            } while (swap == true);//while swaps are still being made

            return scores;
        }

        /// <summary>
        /// Returns the quickest time for the gridSize and bombDensity
        /// </summary>
        /// <param name="gridSize"></param>
        /// <param name="bombDensity"></param>
        /// <returns></returns>
        public static int getHighScore(decimal gridSize, decimal bombDensity)
        {
            int highScore;
            string highest;

            try
            {
                highest = getScores(gridSize, bombDensity)[0];

                highest = highest.Split(new char[] { ':' })[1].Trim();
                highest = highest.Substring(0, highest.Length - 1);

                highScore = Convert.ToInt32(highest);

                return highScore;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Cleans up the score records so they only contain the name and time in a displayable format - 
        /// format = name: time(s)
        /// </summary>
        /// <param name="scores">score records to be sorted</param>
        /// <returns>list containing all the scores in display format</returns>
        private static List<string> getDisplayValues(List<string> scores)
        {
            List<string> toDisplay = new List<string>();
            string[] fields = new string[3];//stores individual fields from a score record
            char[] splitBy = { ',' };

            foreach (string s in scores)
            {
                fields = s.Split(splitBy);
                toDisplay.Add(fields[0] + ": " + fields[1] + "s");
            }

            return toDisplay;
        }
    }
}
