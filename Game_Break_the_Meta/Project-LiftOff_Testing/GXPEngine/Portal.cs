using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Portal : AnimationSprite
{
    public Portal(TiledObject obj) : base("portalRings.png", 5, 1)
    {
        collider.isTrigger = true;
    }

    void Update()
    {
        Animate(0.2f);
    }

    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding is Player)
        {
            ((MyGame)game).LoadLevel("lab");
        }
    }
}
