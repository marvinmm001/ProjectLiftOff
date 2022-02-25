using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Barrier : Sprite
{
    //Barrier doesn't work properly yet:
    //no push back effect

    Sprite barrierImage;

    //Custom Properties
    string barrierName;
    int barrierType;

    public Barrier(TiledObject obj = null) : base("hitboxBarrier.jpg")
    {
        collider.isTrigger = false;

        if (obj != null)
        {
            barrierName = obj.GetStringProperty("barrierName", "barrier");
            barrierType = obj.GetIntProperty("barrierType", 0);

            barrierImage = new Sprite(barrierName + ".png", false, false);
            barrierImage.SetOrigin(barrierImage.width/2, barrierImage.height/2);
            if (barrierType != 0) barrierImage.SetScaleXY(0.125f, 0.35f);
            AddChild(barrierImage);

            alpha = 1;
        }
    }
    void Update()
    {
        
    }

    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding is Bullet bullet && bullet.owner is Player)
        {
            this.LateDestroy();
        }
    }

}
