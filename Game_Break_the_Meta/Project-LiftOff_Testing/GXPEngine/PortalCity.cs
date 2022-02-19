using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

class PortalCity : Sprite
    {
    public PortalCity(TiledObject obj) : base("Portal.png")
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
            ((MyGame)game).LoadLevel("City1");
        }
    }
}

