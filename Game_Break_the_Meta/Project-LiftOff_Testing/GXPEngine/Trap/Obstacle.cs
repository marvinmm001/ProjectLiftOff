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
                case 0: //stump
                    obstacleImage.SetXY(10, 0);
                    obstacleImage.SetScaleXY(0.2f, 0.2f);
                    break;
                case 1: //fence
                    
                    obstacleImage.SetScaleXY(0.3f, 0.3f);
                    break;
                case 2: //table
                    obstacleImage.SetXY(0, 12.5f);
                    obstacleImage.SetScaleXY(0.4f, 0.9f);
                    break;
                case 3: //cityWall
                    obstacleImage.SetXY(0, 0);
                    obstacleImage.SetScaleXY(1.2f, 0.45f);
                    break;
                case 4: //lampVertical
                    obstacleImage.SetXY(0, 0);
                    obstacleImage.SetScaleXY(3, 0.325f);
                    break;
                case 5: //lampHorizontal
                    obstacleImage.SetXY(-2, 0);
                    obstacleImage.SetScaleXY(0.3f, 0.75f);
                    break;
            }

            AddChild(obstacleImage);

            alpha = 1;
        }
    }
}

