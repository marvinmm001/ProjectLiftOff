using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Spike : Sprite
{
    public Spike(TiledObject obj = null) : base("spike.png")
    {
        collider.isTrigger = true;
    }
}

