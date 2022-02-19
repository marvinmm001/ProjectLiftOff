using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Portal : Sprite
{
    AnimationSprite portalImage;
    string portalName;
    int portalType;
    string nextLevel;
    public Portal(TiledObject obj) : base("hitbox.jpg")
    {
        collider.isTrigger = true;

        if (obj != null)
        {
            portalName = obj.GetStringProperty("portalName", "Portal");
            portalType = obj.GetIntProperty("portalType", 0);
            nextLevel = obj.GetStringProperty("nextLevel", "mainMenu");

            int columns;
            int rows;
            if (portalType == 0) columns = rows = 1;
            else
            {
                columns = 5;
                rows = 1;
            }
            portalImage = new AnimationSprite(portalName + ".png", columns, rows, -1, false, false);
            portalImage.SetOrigin(portalImage.width / 2, portalImage.height / 2);
            if (portalType != 0) portalImage.SetScaleXY(3.75f, 13);
            AddChild(portalImage);

            alpha = 0;
        }

        
    }

    void Update()
    {
        portalImage.Animate(0.2f);
    }

    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding is Player)
        {
            if (nextLevel == "mainMenu") game.soundManager.musicChannel.Stop();
            ((MyGame)game).LoadLevel(nextLevel);
        }
    }
}
