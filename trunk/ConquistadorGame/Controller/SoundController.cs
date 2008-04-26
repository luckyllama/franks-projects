using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace ConquistadorGame.Controller {

    public class SoundController {

        public static void PlayDiceRollSound() {
            player = new SoundPlayer(ConquistadorGame.Properties.Resources.DiceRoll);
            player.Play();
        }

        public static void PlayDiceRollSuccessSound() {
            player = new SoundPlayer(ConquistadorGame.Properties.Resources.DiceRollSuccess);
            player.Play();
        }

        public static void PlayDiceRollFailureSound() {
            player = new SoundPlayer(ConquistadorGame.Properties.Resources.DiceRollFailure);
            player.Play();
        }

        public static void PlayCountrySelectSound() {
            player = new SoundPlayer(ConquistadorGame.Properties.Resources.CountrySelect);
            player.Play();
        }

        public static void PlayCountrySelectErrorSound() {
            player = new SoundPlayer(ConquistadorGame.Properties.Resources.CountrySelectError);
            player.Play();
        }

        private static SoundPlayer player;
    }
}
