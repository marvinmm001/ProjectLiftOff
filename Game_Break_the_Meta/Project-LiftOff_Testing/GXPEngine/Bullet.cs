using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;

public class Bullet : AnimationSprite
{
    public Sprite owner;
    int speedX;
    GameObject target;
    
    public Bullet(string filename, int columns, int rows, Sprite pOwner, int pVelocityX) : base(filename, columns, rows)
    {
        owner = pOwner;
        SetXY(pOwner.x, pOwner.y);
        SetOrigin(pOwner.width/2, pOwner.height/2);
        speedX = pVelocityX;
        collider.isTrigger = true;
    }

    public Bullet(string filename, int columns, int rows, Sprite pOwner, int pVelocityX, float scaleX, float scaleY) : base(filename, columns, rows)
    {
        owner = pOwner;
        SetXY(pOwner.x, pOwner.y);
        SetOrigin(pOwner.width / 2, pOwner.height / 2);
        speedX = pVelocityX;
        collider.isTrigger = true;
        
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
            if (objectsColliding is Player)
            {
                game.Health -= 1;
                this.LateDestroy();
                Console.WriteLine("Bullet hits Player, Player's health: " + game.Health);
            }

            if (objectsColliding is Shooter shooter && owner is Player)
            {
                this.LateDestroy();
                shooter.LateDestroy();
            }
        }

        if (objectsColliding is Barrier && owner is Player) this.LateDestroy();
    }
}
