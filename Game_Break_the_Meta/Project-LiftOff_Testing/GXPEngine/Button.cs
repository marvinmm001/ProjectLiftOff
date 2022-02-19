using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Button : Sprite
{
    public string buttonType;
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
        /* if (HitTestPoint(Input.mouseX, Input.mouseY))    
         {
             if (Input.GetMouseButton(0))
             {*/
        if (Input.GetKeyDown(Key.SPACE))
        {
            switch (buttonType)
            {
                case "playButton":

                    ((MyGame)game).LoadLevel("forest1");
                    //game.soundManager.PlaySound(musicSound, "music");

                    break;

                case "restartButton":
                    ((MyGame)game).LoadLevel("mainMenu");
                    break;
            }
        }

        /*     }

         }*/
    }
}

