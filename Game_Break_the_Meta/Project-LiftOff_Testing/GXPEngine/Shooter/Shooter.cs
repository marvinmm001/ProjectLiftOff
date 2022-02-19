using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Shooter : AnimationSprite
{
    //Timing of bullet spawn & shooter animation

    public GameObject target;
    public bool isMirrored;
    int lastTimeAttack = 0;

    bool isIdle;
    bool isAttacking = false;
    int bulletSpeed = 5;

    public Shooter(TiledObject obj) : base("shooter.png", 1, 1)
    {
        collider.isTrigger = true;
    }

    void Update()
    {
        Animate(0.05f);
        if (isIdle) SetCycle(0, 1);
        else if (isAttacking) SetCycle(0, 1);
        
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
        if (currentFrame == 0)
        {
            isAttacking = false;
        }

        if (target.x > this.x)
        {
            Mirror(true, false);
            isMirrored = true;
        }
        else
        {
            Mirror(false, false);
            isMirrored = false;
        }
        if (lastTimeAttack < Time.time && this.currentFrame == 0) ShootBullets();
    }

    void ShootBullets()
    {
        isAttacking = true;
        Bullet bullet = new Bullet("bullet.png", 1, 1, this, isMirrored ? bulletSpeed : -bulletSpeed);
        bullet.SetOrigin(this.width - 50, this.height - 100);
        parent.AddChild(bullet);
        lastTimeAttack = Time.time + 1500;
        //Console.WriteLine("Shooting Bullets");
    }
}

