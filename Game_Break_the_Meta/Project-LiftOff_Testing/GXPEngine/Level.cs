using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;
public class Level : GameObject
{
    TiledLoader loader;

    Player player;
    public Level()
    {
        
    }

    public void CreateLevel(string nameLevel)
    {
        loader = new TiledLoader(nameLevel + ".tmx");

        loader.rootObject = this;

        loader.addColliders = false;
        loader.LoadImageLayers();

        loader.addColliders = true;
        loader.LoadTileLayers();

        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = this.FindObjectOfType<Player>();
        CreateHUD(player);
        if (player != null) SetChildIndex(player, GetChildCount()); //make player the last Index

        Shooter[] shooters = this.FindObjectsOfType<Shooter>();
        {
            foreach (Shooter s in shooters) 
            {
                s.target = player;
            }
        }

        if (nameLevel == "mainMenu") game.Health = 24;
        if (nameLevel == "scoreLevel") CreateScoreDisplay();
    }

    void Update()
    {
        if (player != null) Scrolling();
    }

    void Scrolling()
    {
        float boundary = 300;

        //Scroll Left
        if (player.x + this.x < boundary)
        {
            this.x = boundary + player.x;
        }

        //Scroll Right
        if (player.x + this.x > boundary)
        {
            this.x = boundary - player.x;
        }
    }

    void CreateHUD(Player pTarget)
    {
        if (player == null) return; //if player is null then don't excecute what's underneath
        game.LateAddChild(new HUD(pTarget));
    }

    void CreateScoreDisplay()
    {
        game.LateAddChild(new ScoreDisplay());
    }
}

