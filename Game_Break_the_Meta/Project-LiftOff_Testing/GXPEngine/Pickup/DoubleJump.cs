using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class DoubleJump : Pickup
{
    public DoubleJump(TiledObject obj = null) : base("pickups", 3, 4)
    {
        SetCycle(3, 3);
    }

    void Update()
    {
        Animate(0.02f);
    }
}
