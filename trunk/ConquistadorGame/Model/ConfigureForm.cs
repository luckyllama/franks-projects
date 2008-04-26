using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ConquistadorGame {
    public partial class ConfigureForm : Form {

        #region Constructor

        public ConfigureForm() {
            InitializeComponent();
            showCurrentDiceSettings();
        }

        private void showCurrentDiceSettings() {
            int diceRollDelay = Convert.ToInt32(ConfigurationManager.AppSettings["DiceRollDelay"].ToString());

            foreach (ComboBox.ObjectCollection item in DiceRollDelayComboBox.Items) {
                
            }

            //DiceRollDelayComboBox.SelectedItem
            int endDiceRollDelay = Convert.ToInt32(ConfigurationManager.AppSettings["EndDiceRollDelay"].ToString());
        }

        #endregion Constructor

        #region Handle Events

        private void OkayButton_Click(object sender, EventArgs e) {
            // TODO: save settings
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion Handle Events

    }
}