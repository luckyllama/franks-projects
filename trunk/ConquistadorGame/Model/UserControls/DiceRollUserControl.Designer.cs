namespace ConquistadorGame.UserControls {
    partial class DiceRollUserControl {
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
            this.AttackerLabel = new System.Windows.Forms.Label();
            this.DefenderLabel = new System.Windows.Forms.Label();
            this.ArrowLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AttackerLabel
            // 
            this.AttackerLabel.AutoSize = true;
            this.AttackerLabel.BackColor = System.Drawing.Color.Transparent;
            this.AttackerLabel.Location = new System.Drawing.Point(104, 251);
            this.AttackerLabel.Name = "AttackerLabel";
            this.AttackerLabel.Size = new System.Drawing.Size(47, 13);
            this.AttackerLabel.TabIndex = 0;
            this.AttackerLabel.Text = "Attacker";
            // 
            // DefenderLabel
            // 
            this.DefenderLabel.AutoSize = true;
            this.DefenderLabel.BackColor = System.Drawing.Color.Transparent;
            this.DefenderLabel.Location = new System.Drawing.Point(407, 251);
            this.DefenderLabel.Name = "DefenderLabel";
            this.DefenderLabel.Size = new System.Drawing.Size(51, 13);
            this.DefenderLabel.TabIndex = 1;
            this.DefenderLabel.Text = "Defender";
            // 
            // ArrowLabel
            // 
            this.ArrowLabel.AutoSize = true;
            this.ArrowLabel.BackColor = System.Drawing.Color.Transparent;
            this.ArrowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArrowLabel.ForeColor = System.Drawing.Color.White;
            this.ArrowLabel.Location = new System.Drawing.Point(249, 124);
            this.ArrowLabel.Name = "ArrowLabel";
            this.ArrowLabel.Size = new System.Drawing.Size(65, 39);
            this.ArrowLabel.TabIndex = 2;
            this.ArrowLabel.Text = "VS";
            // 
            // DiceRollUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.ArrowLabel);
            this.Controls.Add(this.DefenderLabel);
            this.Controls.Add(this.AttackerLabel);
            this.Name = "DiceRollUserControl";
            this.Size = new System.Drawing.Size(570, 305);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DiceRollUserControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AttackerLabel;
        private System.Windows.Forms.Label DefenderLabel;
        private System.Windows.Forms.Label ArrowLabel;
    }
}
