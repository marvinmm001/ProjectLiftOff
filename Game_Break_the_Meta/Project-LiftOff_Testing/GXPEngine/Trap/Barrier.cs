using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Barrier : Trap
{
    //Barrier doesn't work properly yet:
        //no push back effect
    
    public int health = 30;
    protected int lastTimeAttacked = 0;

    public Barrier(TiledObject obj = null) : base("closeddoor.png")
    {
        collider.isTrigger = false;
    }
    void Update()
    {
        
    }

    void OnCollision(GameObject objectsColliding)
    {
        if (objectsColliding is Player player)
        {
            if (lastTimeAttacked < Time.time)
            {
                player.Health -= 1;
                player.AddForce(-200, 0);
                lastTimeAttacked = Time.time + 1000;

                Console.WriteLine("Player Hits Barrier, Player's Health: " + player.Health);
            }
        }

        if (objectsColliding is Bullet bullet && bullet.owner is Player)
        {
            this.LateDestroy();
        }
    }

}
