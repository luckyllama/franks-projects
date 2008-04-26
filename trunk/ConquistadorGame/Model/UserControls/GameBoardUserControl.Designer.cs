namespace ConquistadorGame.UserControls {
    partial class GameBoardUserControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.PlayerScore = new ConquistadorGame.Model.UserControls.PlayerScoreUserControl();
            this.SuspendLayout();
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.Location = new System.Drawing.Point(772, 511);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(92, 40);
            this.EndTurnButton.TabIndex = 0;
            this.EndTurnButton.Text = "End Turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // PlayerScore
            // 
            this.PlayerScore.Location = new System.Drawing.Point(11, 511);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(750, 40);
            this.PlayerScore.TabIndex = 1;
            // 
            // GameBoardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.EndTurnButton);
            this.DoubleBuffered = true;
            this.Name = "GameBoardUserControl";
            this.Size = new System.Drawing.Size(875, 560);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameBoardUserCountrol_MouseClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBoardUserControl_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EndTurnButton;
        private ConquistadorGame.Model.UserControls.PlayerScoreUserControl PlayerScore;
    }
}
