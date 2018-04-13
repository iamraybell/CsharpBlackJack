using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack {
    public class MyAudioPlayer {
        public static void playWelcome() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\audio\cb.wav";
            sp.Play();
        }

        public static void playHumanPlayerBust() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\audio\useless.wav";
            sp.Play();
        }

        public static void playStartGame() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\audio\itsTime.wav";
            sp.Play();
        }

        public static void playSeeYou() {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\audio\seeyou.wav";
            sp.Play();
        }
    }
}
