using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class SoundManager
{

    List<SoundChannel> channels = new List<SoundChannel>();
    public SoundChannel musicChannel = new SoundChannel(1);
    SoundChannel levelSounds = new SoundChannel(2);
    SoundChannel globalSounds = new SoundChannel(3);

    public SoundManager()
    {
        channels.Add(musicChannel);

    }

    public void PlaySound(Sound thisSound, string channel)
    {
        switch (channel)
        {
            case ("level"):
                levelSounds = thisSound.Play();
            break;
            case ("global"):
                globalSounds = thisSound.Play();
            break;
            case ("music"):
                musicChannel = thisSound.Play();
            break;
            default:
                //do exception stuff idk
            
                break;
        }
    }
    public void loopSound(Sound thisSound, string channel)
    {

    }


}