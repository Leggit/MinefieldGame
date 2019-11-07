using System;
using System.Windows.Forms;

namespace Minefield1
{
    /// <summary>
    /// Class defining the form used to get the players name when the program starts
    /// </summary>
    public partial class NameInput : Form
    {
        /// <summary>
        /// Creates the form
        /// </summary>
        public NameInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// takes the name from the text box and inputs that to the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkBtn_Click(object sender, EventArgs e)
        {
            if(nameTxt.Text != "")
            {
                MainForm form = new MainForm(nameTxt.Text);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// calls the okBtn method - makes it quicker for user to move forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OkBtn_Click(null, null);
        }
    }
}
