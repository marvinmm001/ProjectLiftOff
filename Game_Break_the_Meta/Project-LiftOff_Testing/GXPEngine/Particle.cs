using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Particle : AnimationSprite
{
    public Particle(string filename, int columns, int rows, float pX, float pY) : base(filename + ".png", columns, rows, -1, false, false)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(pX, pY);
    }

    public Particle(string filename, int columns, int rows, float pX, float pY, float scaleX, float scaleY) : base(filename + ".png", columns, rows, -1, false, false)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(pX, pY);
        SetScaleXY(scaleX, scaleY);
    }

    void Update()
    {
        Animate(0.2f);
        CheckEnd();
    }

    void CheckEnd()
    {
        if (currentFrame == frameCount - 1) Destroy();
    }
}

