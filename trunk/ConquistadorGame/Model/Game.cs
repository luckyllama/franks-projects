using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConquistadorGame {

    public partial class Game : Form {

        public Game() {
            InitializeComponent();
        }

        #region Event Handlers

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e) {
            GameBoardUserControl.NewGame(6);
        }

        private void ConfigureToolStripMenuItem_Click(object sender, EventArgs e) {
            ConfigureForm form = new ConfigureForm();
            form.Show();
        }

        #endregion Event Handlers


    }

}