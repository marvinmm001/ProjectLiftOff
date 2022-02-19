using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;

public class Trap : Sprite
{
    public Trap(string filename) : base(filename)
    {
        //collider.isTrigger = true; //if don't put this code there is no collision happening, Why???
    }
}

