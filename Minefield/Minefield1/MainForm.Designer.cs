namespace Minefield1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.upBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.bombLbl = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.bombIndicatorPanel = new System.Windows.Forms.Panel();
            this.rightBtn = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.submarineBtn = new System.Windows.Forms.RadioButton();
            this.soldierBtn = new System.Windows.Forms.RadioButton();
            this.tankBtn = new System.Windows.Forms.RadioButton();
            this.resetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bombDensity = new System.Windows.Forms.NumericUpDown();
            this.gridSize = new System.Windows.Forms.NumericUpDown();
            this.scoresPanel = new System.Windows.Forms.Panel();
            this.scoresBox = new System.Windows.Forms.ListBox();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.timeLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.helpBtn = new System.Windows.Forms.Button();
            this.background.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bombDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).BeginInit();
            this.scoresPanel.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // upBtn
            // 
            this.upBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.upBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upBtn.Location = new System.Drawing.Point(73, 17);
            this.upBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(51, 53);
            this.upBtn.TabIndex = 1;
            this.upBtn.Text = "⇑";
            this.upBtn.UseVisualStyleBackColor = false;
            this.upBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.downBtn.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downBtn.Location = new System.Drawing.Point(73, 77);
            this.downBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(51, 51);
            this.downBtn.TabIndex = 2;
            this.downBtn.Text = "⇓";
            this.downBtn.UseVisualStyleBackColor = false;
            this.downBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // leftBtn
            // 
            this.leftBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftBtn.Location = new System.Drawing.Point(14, 17);
            this.leftBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(51, 111);
            this.leftBtn.TabIndex = 3;
            this.leftBtn.Text = "⇐";
            this.leftBtn.UseVisualStyleBackColor = false;
            this.leftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // bombLbl
            // 
            this.bombLbl.BackColor = System.Drawing.Color.Salmon;
            this.bombLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bombLbl.Location = new System.Drawing.Point(192, 37);
            this.bombLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bombLbl.Name = "bombLbl";
            this.bombLbl.Size = new System.Drawing.Size(85, 28);
            this.bombLbl.TabIndex = 5;
            this.bombLbl.Text = "0";
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.background.Controls.Add(this.gamePanel);
            this.background.Controls.Add(this.bombIndicatorPanel);
            this.background.Location = new System.Drawing.Point(13, 13);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(962, 916);
            this.background.TabIndex = 6;
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gamePanel.Location = new System.Drawing.Point(209, 88);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(600, 600);
            this.gamePanel.TabIndex = 0;
            // 
            // bombIndicatorPanel
            // 
            this.bombIndicatorPanel.BackColor = System.Drawing.Color.LightGray;
            this.bombIndicatorPanel.Location = new System.Drawing.Point(174, 50);
            this.bombIndicatorPanel.Name = "bombIndicatorPanel";
            this.bombIndicatorPanel.Size = new System.Drawing.Size(664, 664);
            this.bombIndicatorPanel.TabIndex = 1;
            // 
            // rightBtn
            // 
            this.rightBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightBtn.Location = new System.Drawing.Point(132, 17);
            this.rightBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(52, 111);
            this.rightBtn.TabIndex = 4;
            this.rightBtn.Text = "⇒";
            this.rightBtn.UseVisualStyleBackColor = false;
            this.rightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.settingsPanel.Controls.Add(this.submarineBtn);
            this.settingsPanel.Controls.Add(this.soldierBtn);
            this.settingsPanel.Controls.Add(this.tankBtn);
            this.settingsPanel.Controls.Add(this.resetBtn);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.bombDensity);
            this.settingsPanel.Controls.Add(this.gridSize);
            this.settingsPanel.Location = new System.Drawing.Point(981, 79);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(294, 289);
            this.settingsPanel.TabIndex = 1;
            this.settingsPanel.Tag = "";
            // 
            // submarineBtn
            // 
            this.submarineBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.submarineBtn.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.submarineBtn.Image = global::Minefield1.Properties.Resources.submarine;
            this.submarineBtn.Location = new System.Drawing.Point(198, 163);
            this.submarineBtn.Name = "submarineBtn";
            this.submarineBtn.Size = new System.Drawing.Size(79, 49);
            this.submarineBtn.TabIndex = 7;
            this.submarineBtn.UseVisualStyleBackColor = true;
            // 
            // soldierBtn
            // 
            this.soldierBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.soldierBtn.Image = global::Minefield1.Properties.Resources.soldier;
            this.soldierBtn.Location = new System.Drawing.Point(105, 163);
            this.soldierBtn.Name = "soldierBtn";
            this.soldierBtn.Size = new System.Drawing.Size(79, 49);
            this.soldierBtn.TabIndex = 6;
            this.soldierBtn.UseVisualStyleBackColor = true;
            // 
            // tankBtn
            // 
            this.tankBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.tankBtn.Checked = true;
            this.tankBtn.Image = global::Minefield1.Properties.Resources.tank;
            this.tankBtn.Location = new System.Drawing.Point(14, 163);
            this.tankBtn.Name = "tankBtn";
            this.tankBtn.Size = new System.Drawing.Size(79, 49);
            this.tankBtn.TabIndex = 5;
            this.tankBtn.TabStop = true;
            this.tankBtn.UseVisualStyleBackColor = true;
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.Salmon;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.resetBtn.ForeColor = System.Drawing.Color.Black;
            this.resetBtn.Location = new System.Drawing.Point(14, 218);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(263, 53);
            this.resetBtn.TabIndex = 4;
            this.resetBtn.Text = "RESET";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bomb Density: (%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grid Size:";
            // 
            // bombDensity
            // 
            this.bombDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bombDensity.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.bombDensity.Location = new System.Drawing.Point(14, 113);
            this.bombDensity.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.bombDensity.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.bombDensity.Name = "bombDensity";
            this.bombDensity.Size = new System.Drawing.Size(263, 35);
            this.bombDensity.TabIndex = 1;
            this.bombDensity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // gridSize
            // 
            this.gridSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.gridSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gridSize.Location = new System.Drawing.Point(14, 43);
            this.gridSize.Maximum = new decimal(new int[] {
            38,
            0,
            0,
            0});
            this.gridSize.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.gridSize.Name = "gridSize";
            this.gridSize.Size = new System.Drawing.Size(263, 35);
            this.gridSize.TabIndex = 0;
            this.gridSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // scoresPanel
            // 
            this.scoresPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.scoresPanel.Controls.Add(this.scoresBox);
            this.scoresPanel.Location = new System.Drawing.Point(981, 374);
            this.scoresPanel.Name = "scoresPanel";
            this.scoresPanel.Size = new System.Drawing.Size(297, 404);
            this.scoresPanel.TabIndex = 1;
            // 
            // scoresBox
            // 
            this.scoresBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.scoresBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.scoresBox.FormattingEnabled = true;
            this.scoresBox.ItemHeight = 29;
            this.scoresBox.Location = new System.Drawing.Point(14, 16);
            this.scoresBox.Name = "scoresBox";
            this.scoresBox.Size = new System.Drawing.Size(273, 381);
            this.scoresBox.TabIndex = 3;
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.controlsPanel.Controls.Add(this.timeLbl);
            this.controlsPanel.Controls.Add(this.label4);
            this.controlsPanel.Controls.Add(this.label3);
            this.controlsPanel.Controls.Add(this.upBtn);
            this.controlsPanel.Controls.Add(this.downBtn);
            this.controlsPanel.Controls.Add(this.leftBtn);
            this.controlsPanel.Controls.Add(this.rightBtn);
            this.controlsPanel.Controls.Add(this.bombLbl);
            this.controlsPanel.Location = new System.Drawing.Point(981, 784);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(297, 145);
            this.controlsPanel.TabIndex = 2;
            // 
            // timeLbl
            // 
            this.timeLbl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.timeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.timeLbl.Location = new System.Drawing.Point(192, 95);
            this.timeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(85, 33);
            this.timeLbl.TabIndex = 8;
            this.timeLbl.Text = "0s";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(192, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(192, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bombs:";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpBtn.Location = new System.Drawing.Point(982, 13);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(286, 60);
            this.helpBtn.TabIndex = 7;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            this.helpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1287, 941);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.scoresPanel);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.background);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1309, 997);
            this.MinimumSize = new System.Drawing.Size(1309, 997);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.background.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bombDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).EndInit();
            this.scoresPanel.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button upBtn;
        private System.Windows.Forms.Button downBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Label bombLbl;
        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Panel scoresPanel;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.NumericUpDown bombDensity;
        private System.Windows.Forms.NumericUpDown gridSize;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Panel bombIndicatorPanel;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.ListBox scoresBox;
        private System.Windows.Forms.RadioButton submarineBtn;
        private System.Windows.Forms.RadioButton soldierBtn;
        private System.Windows.Forms.RadioButton tankBtn;
    }
}

