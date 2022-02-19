using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public abstract class Pickup : AnimationSprite
{
    public Pickup(string filename, int columns, int rows) : base(filename + ".png", columns, rows)
    {
        collider.isTrigger = true;
    }
}

