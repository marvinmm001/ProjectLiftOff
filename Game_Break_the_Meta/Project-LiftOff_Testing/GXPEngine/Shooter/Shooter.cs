using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Shooter : Sprite
{
    //Timing of bullet spawn & shooter animation

    public GameObject target;
    public bool isMirrored;
    int lastTimeAttack = 0;

    bool isIdle;
    bool isAttacking = false;
    int bulletSpeed = 5;
    string bulletImage;

    //Custom Properties
    Sprite shooterImage;
    string shooterName;
    int shooterType;

    public Shooter(TiledObject obj) : base("hitboxShooter.jpg")
    {
        collider.isTrigger = true;

        if (obj != null)
        {
            shooterName = obj.GetStringProperty("shooterName", "shooter");
            shooterType = obj.GetIntProperty("shooterType", 0);
            
            shooterImage = new Sprite(shooterName + ".png", false, false);
            shooterImage.SetOrigin(shooterImage.width/2, shooterImage.height/2);
            if (shooterType != 0) shooterImage.SetScaleXY(1.5f, 0.25f);
            else shooterImage.SetScaleXY(1.2f, 1);
            AddChild(shooterImage);
            
            alpha = 1;
        }
    }

    void Update()
    {
        /*Animate(0.05f);
        if (isIdle) SetCycle(0, 1);
        else if (isAttacking) SetCycle(0, 1);*/
        
        ManageIdle();
    }

    void ManageIdle()
    {
        if ((DistanceTo(target) < 400))
        {
            ManageAttack();
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }
    }

    void ManageAttack()
    {
        /*if (currentFrame == 0)
        {
            isAttacking = false;
        }*/

        if (target.x > this.x)
        {
            shooterImage.Mirror(true, false);
            isMirrored = true;
        }
        else
        {
            shooterImage.Mirror(false, false);
            isMirrored = false;
        }
        if (lastTimeAttack < Time.time /*&& this.currentFrame == 0*/) ShootBullets();
    }

    void ShootBullets()
    {
        isAttacking = true;
        if (shooterName == "shooterForest") bulletImage = "bulletForest";
        else bulletImage = "bullet";

        Bullet bullet = new Bullet(bulletImage + ".png", 1, 1, this, isMirrored ? bulletSpeed : -bulletSpeed);
        bullet.SetOrigin(this.width - 50, this.height - 100);
        if (isMirrored) bullet.Mirror(true, false);
        parent.AddChild(bullet);
        lastTimeAttack = Time.time + 1500;

        //Console.WriteLine("Shooting Bullets");
    }
}

