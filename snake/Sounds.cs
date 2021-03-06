using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;


namespace snake
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds()
        {
        }

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            player.URL = pathToMedia + "title.mp3";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        public void PlayLost()
        {
            player.URL = pathToMedia + "gameover.mp3";
            player.settings.volume = 50;
            player.controls.play();
        }

        public void PlayEat()
        {
            player.URL = pathToMedia + "eat.mp3";
            player.settings.volume = 50;
            player.controls.play();
        }
    }
}
