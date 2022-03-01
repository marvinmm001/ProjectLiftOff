using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Button : Sprite
{
    public string buttonType;
    bool soundPlaying;
    public Button(TiledObject obj = null) : base("square.png")
    {
        if (obj != null)
        {
            buttonType = obj.GetStringProperty("buttonType", null);
        }
    }

    Sound musicSound = new Sound("music.mp3", true, true);
    void Update()
    {
        if (Input.GetKeyDown(Key.SPACE))
        {
            switch (buttonType)
            {
                case "playButton":

                    ((MyGame)game).LoadLevel("forest1");
                    //game.soundManager.PlaySound(musicSound, "music");
                    soundPlaying = true;

                    break;

                case "restartButton":
                    ((MyGame)game).LoadLevel("mainMenu");
                    soundPlaying = false;
                    break;
            }
        }

        Sound();
    }

    void Sound()
    {
        if (soundPlaying)
        {
            game.soundManager.PlaySound(musicSound, "music");
        }
        else 
        {
            game.soundManager.musicChannel.Stop();
        }
    }
}

