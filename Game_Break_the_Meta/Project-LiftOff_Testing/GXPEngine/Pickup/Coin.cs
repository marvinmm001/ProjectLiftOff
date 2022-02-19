using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Coin : Pickup
{
    public string coinType;
    public Coin(TiledObject obj = null) : base("gameCoin", 14, 1)
    {
        if (obj != null)
        {
            coinType = obj.GetStringProperty("coinType", null);
        }


    }

    void Update()
    {
        Animate(0.2f);
    }
}
