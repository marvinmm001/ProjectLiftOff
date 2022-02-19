using System;
using GXPEngine;
using System.Collections.Generic;
using System.Drawing;
using TiledMapParser;
using System.IO.Ports;
using System.Threading;

public class MyGame : Game
{
    //Create a countdown timer for DoubleJump powerup
    //Push back effects on Player is touches Barrier
    //FIX: 
        //Player just have to keep moving forward without being able to turn back
        //Health of the player to only be 3 hearts and the hearts disappear if player got damage

    Player player;

    Level level;
    

    public MyGame() : base(1366, 768, false)
    {
        /*player = new Player();
		AddChild(player);*/
        arduino = new ArduinoInput();
        AddChild(arduino);
        LoadLevel("mainMenu");
    }


    public void Update()
    {
        if (Input.GetKey(Key.Q)) LoadLevel("forest1");
        if (Input.GetKey(Key.R)) Console.WriteLine(currentFps);
    }

    static void Main()
    {
        //new SerialPortProgram().Start();
        new MyGame().Start();
    }


  /*  private void SerialPortProgram()
    {

        SerialPort port = new SerialPort();

        port.PortName = "COM3";
        port.BaudRate = 9600;
        port.RtsEnable = true;
        port.DtrEnable = true;
        port.Open();

        while (true)
        {
            string a = port.ReadLine();
            if (a != "")
            {
                Console.WriteLine("Read from port: '" + a + "'");
                leverValue = int.Parse(a);
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                port.Write(key.KeyChar.ToString());
            }

            Thread.Sleep(30);
        }
    }
*/
public void LoadLevel(string levelFilename)
    {
        DestroyLevel();
        level = new Level();
        LateAddChild(level);
        level.CreateLevel(levelFilename);
    }

    void DestroyLevel()
    {
        List<GameObject> children = GetChildren();
        foreach (GameObject c in children)
        {
            c.LateDestroy();
        }
    }
}