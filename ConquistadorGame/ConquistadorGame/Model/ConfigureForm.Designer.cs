namespace ConquistadorGame {
    partial class ConfigureForm {
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
            this.OkayButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DiceRollWindowGroupBox = new System.Windows.Forms.GroupBox();
            this.DiceDelayLabel = new System.Windows.Forms.Label();
            this.DiceRollDelayComboBox = new System.Windows.Forms.ComboBox();
            this.DiceClosingDelayLabel = new System.Windows.Forms.Label();
            this.EndDiceRollDelayComboBox = new System.Windows.Forms.ComboBox();
            this.DiceRollWindowGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(328, 414);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 0;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(409, 414);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DiceRollWindowGroupBox
            // 
            this.DiceRollWindowGroupBox.Controls.Add(this.EndDiceRollDelayComboBox);
            this.DiceRollWindowGroupBox.Controls.Add(this.DiceClosingDelayLabel);
            this.DiceRollWindowGroupBox.Controls.Add(this.DiceRollDelayComboBox);
            this.DiceRollWindowGroupBox.Controls.Add(this.DiceDelayLabel);
            this.DiceRollWindowGroupBox.Location = new System.Drawing.Point(12, 349);
            this.DiceRollWindowGroupBox.Name = "DiceRollWindowGroupBox";
            this.DiceRollWindowGroupBox.Size = new System.Drawing.Size(472, 59);
            this.DiceRollWindowGroupBox.TabIndex = 2;
            this.DiceRollWindowGroupBox.TabStop = false;
            this.DiceRollWindowGroupBox.Text = "Dice Roll Window";
            // 
            // DiceDelayLabel
            // 
            this.DiceDelayLabel.AutoSize = true;
            this.DiceDelayLabel.Location = new System.Drawing.Point(6, 26);
            this.DiceDelayLabel.Name = "DiceDelayLabel";
            this.DiceDelayLabel.Size = new System.Drawing.Size(133, 13);
            this.DiceDelayLabel.TabIndex = 0;
            this.DiceDelayLabel.Text = "Delay Between Dice Rolls:";
            // 
            // DiceRollDelayComboBox
            // 
            this.DiceRollDelayComboBox.FormattingEnabled = true;
            this.DiceRollDelayComboBox.Items.AddRange(new object[] {
            "None",
            "0.5 Second",
            "1 Second",
            "1.5 Seconds",
            "2 Seconds"});
            this.DiceRollDelayComboBox.Location = new System.Drawing.Point(145, 23);
            this.DiceRollDelayComboBox.Name = "DiceRollDelayComboBox";
            this.DiceRollDelayComboBox.Size = new System.Drawing.Size(95, 21);
            this.DiceRollDelayComboBox.TabIndex = 1;
            // 
            // DiceClosingDelayLabel
            // 
            this.DiceClosingDelayLabel.AutoSize = true;
            this.DiceClosingDelayLabel.Location = new System.Drawing.Point(246, 26);
            this.DiceClosingDelayLabel.Name = "DiceClosingDelayLabel";
            this.DiceClosingDelayLabel.Size = new System.Drawing.Size(108, 13);
            this.DiceClosingDelayLabel.TabIndex = 2;
            this.DiceClosingDelayLabel.Text = "Delay Before Closing:";
            // 
            // EndDiceRollDelayComboBox
            // 
            this.EndDiceRollDelayComboBox.FormattingEnabled = true;
            this.EndDiceRollDelayComboBox.Items.AddRange(new object[] {
            "On Click",
            "1 Second",
            "2 Seconds",
            "3 Seconds",
            "4 Seconds ",
            "5 Seconds"});
            this.EndDiceRollDelayComboBox.Location = new System.Drawing.Point(360, 23);
            this.EndDiceRollDelayComboBox.Name = "EndDiceRollDelayComboBox";
            this.EndDiceRollDelayComboBox.Size = new System.Drawing.Size(106, 21);
            this.EndDiceRollDelayComboBox.TabIndex = 3;
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 449);
            this.Controls.Add(this.DiceRollWindowGroupBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ConfigureForm";
            this.DiceRollWindowGroupBox.ResumeLayout(false);
            this.DiceRollWindowGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox DiceRollWindowGroupBox;
        private System.Windows.Forms.Label DiceDelayLabel;
        private System.Windows.Forms.ComboBox EndDiceRollDelayComboBox;
        private System.Windows.Forms.Label DiceClosingDelayLabel;
        private System.Windows.Forms.ComboBox DiceRollDelayComboBox;
    }
}