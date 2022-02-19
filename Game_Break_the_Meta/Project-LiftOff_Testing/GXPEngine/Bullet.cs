using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

public class Bullet : AnimationSprite
{
    //the collision check for bullet is destroying each other(FIXED)
    //MUST FIX: bullet from shooter can destroy barrier (FIXED)

    public Sprite owner;
    int speedX;
    GameObject target;
    
    public Bullet(string filename, int columns, int rows, Sprite pOwner, int pVelocityX) : base(filename, columns, rows)
    {
        owner = pOwner;
        SetXY(pOwner.x, pOwner.y);
        SetOrigin(pOwner.width/2, pOwner.height/2);
        speedX = pVelocityX;
       
    }

    public Bullet(string filename, int columns, int rows, Sprite pOwner, int pVelocityX, float scaleX, float scaleY) : base(filename, columns, rows)
    {
        owner = pOwner;
        SetXY(pOwner.x, pOwner.y);
        SetOrigin(pOwner.width / 2, pOwner.height / 2);
        speedX = pVelocityX;
        
        SetScaleXY(scaleX, scaleY);
    }

    void Update()
    {
        Animate(0.2f);
        BulletMovement();
    }

    void BulletMovement()
    {
        Move(speedX, 0);
    }


    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding != owner)
        {
            if (objectsColliding is Player player)
            {
                player.Health -= 1;
                this.LateDestroy();
                Console.WriteLine("Bullet hits Player, Player's health: " + player.Health);
            }

            if (objectsColliding is Shooter shooter)
            {
                //shooter.health -= 5;
                //parent.LateAddChild(new Particle("smoke", 12, 7, this.x, this.y, 0.2f, 0.2f));
                this.LateDestroy();
                shooter.LateDestroy();
                
                //Console.WriteLine("Bullet hits Shooter, Shooter's health: " + shooter.health);
            }
        }

        if (owner is Player && objectsColliding is Barrier) this.LateDestroy();
    }
}
