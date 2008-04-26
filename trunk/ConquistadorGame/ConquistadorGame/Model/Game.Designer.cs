namespace ConquistadorGame {
    partial class Game {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameBoardUserControl = new ConquistadorGame.UserControls.GameBoardUserControl();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(897, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // GameToolStripMenuItem
            // 
            this.GameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameToolStripMenuItem,
            this.SaveGameToolStripMenuItem,
            this.LoadGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.ConfigureToolStripMenuItem});
            this.GameToolStripMenuItem.Name = "GameToolStripMenuItem";
            this.GameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.GameToolStripMenuItem.Text = "Game";
            // 
            // NewGameToolStripMenuItem
            // 
            this.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            this.NewGameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.NewGameToolStripMenuItem.Text = "New Game...";
            this.NewGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // SaveGameToolStripMenuItem
            // 
            this.SaveGameToolStripMenuItem.Name = "SaveGameToolStripMenuItem";
            this.SaveGameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.SaveGameToolStripMenuItem.Text = "Save Game...";
            // 
            // LoadGameToolStripMenuItem
            // 
            this.LoadGameToolStripMenuItem.Name = "LoadGameToolStripMenuItem";
            this.LoadGameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.LoadGameToolStripMenuItem.Text = "Load Game...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // ConfigureToolStripMenuItem
            // 
            this.ConfigureToolStripMenuItem.Name = "ConfigureToolStripMenuItem";
            this.ConfigureToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ConfigureToolStripMenuItem.Text = "Configure...";
            this.ConfigureToolStripMenuItem.Click += new System.EventHandler(this.ConfigureToolStripMenuItem_Click);
            // 
            // GameBoardUserControl
            // 
            this.GameBoardUserControl.BackColor = System.Drawing.Color.White;
            this.GameBoardUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameBoardUserControl.Location = new System.Drawing.Point(12, 30);
            this.GameBoardUserControl.Name = "GameBoardUserControl";
            this.GameBoardUserControl.Size = new System.Drawing.Size(875, 560);
            this.GameBoardUserControl.TabIndex = 0;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 602);
            this.Controls.Add(this.GameBoardUserControl);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Game";
            this.Text = "Conquistador";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConquistadorGame.UserControls.GameBoardUserControl GameBoardUserControl;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem GameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ConfigureToolStripMenuItem;
    }
}

