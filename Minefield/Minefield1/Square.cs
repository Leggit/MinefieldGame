using System.Drawing;
using System.Windows.Forms;

namespace Minefield1
{
    /// <summary>
    /// Class containing the data and methods for creating a square to show on the gameboard
    /// </summary>
    class Square : Label
    {
        public bool isBomb;
 
        Panel panel;//panel on which to place the square

        public const int SIZE = 15;//pixel size of squares

        //images for squares 
        public static Image endMarker = Properties.Resources.marker;
        public static Image tankIcon = Properties.Resources.tank;
        public static Image soldierIcon = Properties.Resources.soldier;
        public static Image submarineIcon = Properties.Resources.submarine_front_view;
        public static Image bomb = Properties.Resources.bomb;
        public static Image explosion = Properties.Resources.explosion;

        //square color set
        public static Color defaultColor;//this is changed depending on the avatar selected
        public static Color trailColor = Color.SandyBrown;
        public static Color nonBombRevealColor = Color.RosyBrown;

        /// <summary>
        /// creates a square in the specified position on the panel
        /// </summary>
        /// <param name="isBomb">Decides if the square should be a bomb</param>
        /// <param name="x"> x co-ordinate </param>
        /// <param name="y"> y co-ordinate </param>
        /// <param name="color"> Specifies the color of the square </param>
        public Square(bool isBomb, int x, int y, Panel panel)
        {
            this.isBomb = isBomb;
            
            this.AutoSize = false;
            this.Location = new System.Drawing.Point(x,y);
            this.Size = new System.Drawing.Size(SIZE, SIZE);
            this.BackColor = defaultColor;

            //put the square on the panel
            this.panel = panel;
            add();
        }
        
        /// <summary>
        /// Removes this square from the panel 
        /// </summary>
        public void remove()
        {
            panel.Controls.Remove(this);
        }

        /// <summary>
        /// adds this square to the panel
        /// </summary>
        public void add()
        {
            panel.Controls.Add(this);
        }
    }
}
