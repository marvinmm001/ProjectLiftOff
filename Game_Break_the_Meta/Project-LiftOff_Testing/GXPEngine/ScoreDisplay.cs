using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;
using TiledMapParser;
public class ScoreDisplay : EasyDraw
{

    public ScoreDisplay() : base(500, 150, false)
    {
        TextSize(10);
    }

    void Update()
    {
        Fill(Color.White);
        Text(game.score.ToString(), 250, 75);
    }
}

