using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Spike : Trap
{
    public Spike(TiledObject obj = null) : base("grassSpike.png")
    {
        collider.isTrigger = true;
    }
}

