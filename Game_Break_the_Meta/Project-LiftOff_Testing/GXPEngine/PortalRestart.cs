using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

class PortalRestart : Sprite
    {
    public PortalRestart(TiledObject obj) : base("Portal.png")
    {
        collider.isTrigger = true;
    }

    void Update()
    {
        
    }

    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding is Player)
        {
            game.soundManager.musicChannel.Stop();
            ((MyGame)game).LoadLevel("mainMenu");
        }
    }
}
