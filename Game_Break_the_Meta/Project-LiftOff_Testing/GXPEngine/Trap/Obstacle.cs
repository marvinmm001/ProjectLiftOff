using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Obstacle : Sprite
{
    Sprite obstacleImage;
    string obstacleName;
    int obstacleType;

    public Obstacle(TiledObject obj) : base("hitboxObstacle.jpg")
    {
        collider.isTrigger = false;
        
        if (obj != null)
        {
            obstacleName = obj.GetStringProperty("obstacleName", "stump");
            obstacleType = obj.GetIntProperty("obstacleType", 0);

            obstacleImage = new Sprite(obstacleName + ".png", false, false);
            obstacleImage.SetOrigin(obstacleImage.width/2, obstacleImage.height/2);
            switch (obstacleType)
            {
                case 0:
                    obstacleImage.SetScaleXY(0.2f, 0.2f);
                    break;
                case 1:
                    //obstacleImage.SetScaleXY();
                    break;
                case 2:
                    //obstacleImage.SetScaleXY();
                    break;
                //so on...
            }
            AddChild(obstacleImage);

            alpha = 1;
        }
    }
}

