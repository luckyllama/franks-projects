using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GameObjects;
using System.Resources;
using ConquistadorGame.Controller;
using ConquistadorGame.Model;

namespace ConquistadorGame.UserControls {

    public partial class DiceRollUserControl : UserControl {

        public DiceRollUserControl() {
            InitializeComponent();
        }

        #region Make Background Transparent

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected void InvalidateEx() {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            // do nothing
        }

        #endregion Make Background Transparent

        #region Methods

        public bool RollDice(PlayerColor attacker, int attackerArmyCount, PlayerColor defender, int defenderArmyCount) {
            this.attacker = attacker;
            this.attackerCount = attackerArmyCount;
            this.attackerRolls = new List<int>();
            this.defender = defender;
            this.defenderCount = defenderArmyCount;
            this.defenderRolls = new List<int>();
            this.rollIsFinished = false;

            int totalRollsNeeded = (attackerArmyCount > defenderArmyCount ? attackerArmyCount : defenderArmyCount);

            for (int rollIndex = 0; rollIndex < totalRollsNeeded; rollIndex++) {
                Random random = new Random();
                if (rollIndex < attackerArmyCount) {
                    int attackerRoll = random.Next(6) + 1;
                    attackerRolls.Add(attackerRoll);
                }
                if (rollIndex < defenderArmyCount) {
                    int defenderRoll = random.Next(6) + 1;
                    defenderRolls.Add(defenderRoll);
                }
                SoundController.PlayDiceRollSound();
                displayAndPause(PAUSE_BETWEEN_ROLL_DURATION);
            }

            rollIsFinished = true;
            bool result;
            if (attackerRollTotal > defenderRollTotal) {
                SoundController.PlayDiceRollSuccessSound();
                result = true;
            } else {
                SoundController.PlayDiceRollFailureSound();
                result = false;
            }

            displayAndPause(END_PAUSE_DURATION);

            return result;
        }

        private void displayAndPause(int pauseDuration) { 
            this.Invalidate();
            this.Update();

            // TODO: does this work?
            // To prevent unresponsiveness, sleep at small intervals so the program
            // can check for events in between sleeping (like closing the application).
            int intermittantDuration = 10;
            int totalPaused = 0;
            while (totalPaused < pauseDuration) {
                System.Threading.Thread.Sleep(intermittantDuration);
                totalPaused += intermittantDuration;
            }
        }

        #endregion Methods

        #region Paint Method

        private void DiceRollUserControl_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            // draw backgroud
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Color firstColor = Color.FromArgb(64, 64, 64);
            Color secondColor = Color.FromArgb(98, 98, 98);
            LinearGradientBrush brush = new LinearGradientBrush(rect, firstColor, secondColor, 90);
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, brush, 0, 0, this.Width, this.Height, 5);
            //RoundRectangleCreater.DrawOutlinedRoundRectangle(graphics, new Pen(Color.Black, 2), 0, 0, this.Width, this.Height, 5);

            drawSide(graphics, true, attacker, attackerCount, ATTACKER_SIDE_X);
            drawSide(graphics, false, defender, defenderCount, DEFENDER_SIDE_X);
        }

        

        private void drawSide(Graphics graphics, bool isAttacker, PlayerColor color, int armyCount, int x) {
            if (isAttacker) {
                AttackerLabel.Text = color.ToString() + " - " + armyCount;
            } else {
                DefenderLabel.Text = color.ToString() + " - " + armyCount;
            }

            if (rollIsFinished) {
                HatchBrush hatchBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, PlayerColorUtil.GetPlayerColor(color), Color.DimGray);
                Pen solidPen = new Pen(PlayerColorUtil.GetPlayerColor(color), 2);
                if (isAttacker && attackerWins) {
                    RoundRectangleCreater.DrawFilledRoundRectangle(graphics, hatchBrush, ATTACKER_SIDE_BORDER_X, SIDE_BORDER_Y, SIDE_BORDER_WIDTH, SIDE_BORDER_HEIGHT, ROUNDED_BORDER_RADIUS);
                    RoundRectangleCreater.DrawOutlinedRoundRectangle(graphics, solidPen, ATTACKER_SIDE_BORDER_X, SIDE_BORDER_Y, SIDE_BORDER_WIDTH, SIDE_BORDER_HEIGHT, ROUNDED_BORDER_RADIUS);
                } else if (!isAttacker && !attackerWins) {
                    RoundRectangleCreater.DrawFilledRoundRectangle(graphics, hatchBrush, DEFENDER_SIDE_BORDER_X, SIDE_BORDER_Y, SIDE_BORDER_WIDTH, SIDE_BORDER_HEIGHT, ROUNDED_BORDER_RADIUS);
                    RoundRectangleCreater.DrawOutlinedRoundRectangle(graphics, solidPen, DEFENDER_SIDE_BORDER_X, SIDE_BORDER_Y, SIDE_BORDER_WIDTH, SIDE_BORDER_HEIGHT, ROUNDED_BORDER_RADIUS);                
                }
            }

            // draw large dice background
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, Brushes.White, x, BIG_DICE_BACKGROUND_Y, BIG_DICE_BACKGROUND_WIDTH, BIG_DICE_BACKGROUND_HEIGHT, ROUNDED_BORDER_RADIUS);
            // draw rolls background
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, Brushes.White, x, TOTAL_DICE_BACKGROUND_Y, BIG_DICE_BACKGROUND_WIDTH, TOTAL_DICE_BACKGROUND_HEIGHT, ROUNDED_BORDER_RADIUS);
            // draw total roll background
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, Brushes.White, x, TOTAL_ROLL_COUNT_BACKGROUND_Y, BIG_DICE_BACKGROUND_WIDTH, TOTAL_ROLL_COUNT_BACKGROUND_HEIGHT, ROUNDED_BORDER_RADIUS);
            
            // draw label background
            Brush labelBrush = new SolidBrush(PlayerColorUtil.GetPlayerColor(color));
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, labelBrush, x, SIDE_LABEL_Y, BIG_DICE_BACKGROUND_WIDTH, SIDE_LABEL_HEIGHT, ROUNDED_BORDER_RADIUS);
            drawRolls(graphics, isAttacker, x);
        }

        private void drawRolls(Graphics graphics, bool isAttacker, int x) {
            if (isAttacker) {
                if (attackerRolls.Count > 0) {
                    drawBigDice(graphics, x, attackerRolls[attackerRolls.Count - 1]);
                    drawDiceTotals(graphics, x, attackerRolls.ToArray());
                }
            } else {
                if (defenderRolls.Count > 0) {
                    drawBigDice(graphics, x, defenderRolls[defenderRolls.Count - 1]);
                    drawDiceTotals(graphics, x, defenderRolls.ToArray());
                }
            }
        }

        private void drawBigDice(Graphics graphics, int x, int dieRoll) {
            Bitmap image = getBigDieImage(dieRoll);
            graphics.DrawImage(image, x+5, BIG_DICE_Y);
        }

        private static Bitmap getBigDieImage(int dieRoll) {
            Bitmap image;
            switch (dieRoll) {
                case 1:
                    image = ConquistadorGame.Properties.Resources.BigDie1;
                    break;
                case 2:
                    image = ConquistadorGame.Properties.Resources.BigDie2;
                    break;
                case 3:
                    image = ConquistadorGame.Properties.Resources.BigDie3;
                    break;
                case 4:
                    image = ConquistadorGame.Properties.Resources.BigDie4;
                    break;
                case 5:
                    image = ConquistadorGame.Properties.Resources.BigDie5;
                    break;
                default:
                    image = ConquistadorGame.Properties.Resources.BigDie6;
                    break;
            }
            return image;
        }

        private void drawDiceTotals(Graphics graphics, int x, int[] diceRolls) {
            Font font = new Font(FontFamily.GenericSansSerif, 12);
            int total = 0;
            for (int rollIndex = 0; rollIndex < diceRolls.Length; rollIndex++) {
                total += diceRolls[rollIndex];
                Bitmap image = getSmallDieImage(diceRolls[rollIndex]);
                if (rollIndex < 5) {
                    graphics.DrawImage(image, (x + 5) + (rollIndex * 27), TOTAL_DICE_BACKGROUND_Y);
                } else {
                    graphics.DrawImage(image, (x + 5) + (rollIndex * 27), TOTAL_DICE_BACKGROUND_Y - 25);
                }
            }
            graphics.DrawString("Total: " + total.ToString(), font, Brushes.Black, x + 5, TOTAL_ROLL_COUNT_BACKGROUND_Y);
        }

        private static Bitmap getSmallDieImage(int dieRoll) {
            Bitmap image;
            switch (dieRoll) {
                case 1:
                    image = ConquistadorGame.Properties.Resources.SmallDie1;
                    break;
                case 2:
                    image = ConquistadorGame.Properties.Resources.SmallDie2;
                    break;
                case 3:
                    image = ConquistadorGame.Properties.Resources.SmallDie3;
                    break;
                case 4:
                    image = ConquistadorGame.Properties.Resources.SmallDie4;
                    break;
                case 5:
                    image = ConquistadorGame.Properties.Resources.SmallDie5;
                    break;
                default:
                    image = ConquistadorGame.Properties.Resources.SmallDie6;
                    break;
            }
            return image;
        }

        #endregion Paint Method

        #region Properties & Fields

        private bool rollIsFinished = false;

        private PlayerColor attacker;

        private List<int> attackerRolls = new List<int>();

        private int attackerRollTotal {
            get {
                int totalRoll = 0;
                foreach (int roll in attackerRolls) {
                    totalRoll += roll;
                }
                return totalRoll;
            }
        }

        private int attackerCount = 1;

        private PlayerColor defender;

        private List<int> defenderRolls = new List<int>();

        private int defenderRollTotal {
            get {
                int totalRoll = 0;
                foreach (int roll in defenderRolls) {
                    totalRoll += roll;
                }
                return totalRoll;
            }
        }

        private int defenderCount = 1;

        private bool attackerWins {
            get { return attackerRollTotal > defenderRollTotal; }
        }

        private const int PAUSE_BETWEEN_ROLL_DURATION = 500;
        private const int END_PAUSE_DURATION = 1000;
        private const int ROUNDED_BORDER_RADIUS = 5;
        private const int ATTACKER_SIDE_X = 60;
        private const int DEFENDER_SIDE_X = 360;
        private const int BIG_DICE_BACKGROUND_Y = 30;
        private const int BIG_DICE_BACKGROUND_WIDTH = 150;
        private const int BIG_DICE_BACKGROUND_HEIGHT = 180;
        private const int BIG_DICE_Y = 35;
        private const int TOTAL_DICE_BACKGROUND_Y = 185;
        private const int TOTAL_DICE_BACKGROUND_HEIGHT = 25;
        private const int TOTAL_ROLL_COUNT_BACKGROUND_Y = 215;
        private const int TOTAL_ROLL_COUNT_BACKGROUND_HEIGHT = 25;
        private const int SIDE_LABEL_Y = 245;
        private const int SIDE_LABEL_HEIGHT = 25;

        private const int ATTACKER_SIDE_BORDER_X = ATTACKER_SIDE_X - 10;
        private const int DEFENDER_SIDE_BORDER_X = DEFENDER_SIDE_X - 10;
        private const int SIDE_BORDER_Y = BIG_DICE_BACKGROUND_Y - 10;
        private const int SIDE_BORDER_WIDTH = BIG_DICE_BACKGROUND_WIDTH + 20;
        private const int SIDE_BORDER_HEIGHT = SIDE_LABEL_Y + 15;

        #endregion Properties & Fields

    }
}
