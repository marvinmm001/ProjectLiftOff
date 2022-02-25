using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using System.Drawing;
public class HUD : Canvas
{
    Player player;
    //EasyDraw healthBar;
    AnimationSprite lives;
    int currentLife;
    int framesToAnimate;

    public HUD(Player pTarget) : base(100, 100, false)
    {
        player = pTarget;
        currentLife = game.Health;

        lives = new AnimationSprite("heartsAnimation.png", 1, 21, -1, false, false);
        lives.SetCycle(0, 21);
        lives.SetScaleXY(0.15f, 0.15f);
        AddChild(lives);
        framesToAnimate = 0;

        if (game.Health <= 20)
        {
            if (game.Health >= 16) framesToAnimate = 4;
            else if (game.Health >= 12) framesToAnimate = 8;
            else if (game.Health >= 8) framesToAnimate = 12;
            else if (game.Health >= 4) framesToAnimate = 16;
        }
    }

    void Update()
    {
        /*healthBar.Clear(Color.Red);
        healthBar.Fill(Color.Green);
        healthBar.Rect(0, 0, game.Health * 4, 40); */

        if (framesToAnimate > 20) framesToAnimate = 0;
        if (currentLife > game.Health)
        {
            currentLife = game.Health;
            if (currentLife % 4 == 0) framesToAnimate += 4;
        }
        if (framesToAnimate > lives.currentFrame)
        {
            lives.Animate(0.12f);
        }

        graphics.Clear(Color.Empty);
        graphics.DrawString("Score  " + game.score, SystemFonts.DefaultFont, Brushes.AntiqueWhite, 5, 50);
        
    }
}
