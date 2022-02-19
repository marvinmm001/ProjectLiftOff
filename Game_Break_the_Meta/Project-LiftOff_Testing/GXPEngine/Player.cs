using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;
public class Player : Sprite
{
    //Figure out how to make jumping & double jumping with a timer

    //FIX:
    //Clean up the code for HorizontalMovement
    //When Sliding the bullets aren't moving along

    //HorizontalMovement
    float speedX = 0;
    float horizontalSpeed = 0.05f;
    bool isSliding = false;

    //VerticalMovement
    float verticalSpeed;
    bool isGrounded;
    int numberOfJump;
    int maxNumberOfJump = 1;

    //Shooting
    int lastTimeShot = 0;
    int lastTimeAttacked = 0;

    //Collectables
    int _health = 24;
    public int Health { get => _health; set => _health = value; }
    //int bullets;
    int bulletSpeed = 5;
    public int coins = 0;
    public bool started = false;
    public bool canceler = false;


    float currentLeverValue = 0;
    AimIndicator aimIndicator = new AimIndicator();

    AnimationSprite playerImage;
    int columns = 10;
    int rows = 1;

    public Player(TiledObject obj) : base("hitboxPlayer.jpg")
    {
        collider.isTrigger = true;
        //AddChild(aimIndicator);

        if (obj != null)
        {
            playerImage = new AnimationSprite("player1.png", columns, rows, -1, false, false);
            playerImage.SetXY(-600, -150);
            Console.WriteLine("imageWidth: {0}, imageHeight: {1}", playerImage.x, playerImage.y);
            //playerImage.SetOrigin(playerImage.x, playerImage.y);
            playerImage.SetScaleXY(8, 3);
            AddChild(playerImage);
        }
       
    }

    void SmoothLeverValue()
    {
        currentLeverValue *= 0.9f;
        currentLeverValue += 0.1f * game.arduino.GetLeverValue();
    }

    void Update()
    {
        if (canceler == false)
        {
            checkIfStarted();
        }
        playerImage.Animate(0.12f);
        HorizontalMovement();
        VerticalMovement();
        if (lastTimeShot < Time.time) Shooting();
        
        CheckHealth();

        SmoothLeverValue();
        aimIndicator.SetAimingDirection(aimIndicator.MapLeverValue(currentLeverValue));

        //--------------------------------------------------------------------------------------
       /* if (isSliding) this._scaleY = 0.5f;
        else this.SetScaleXY(1,1);*/
    }

    void HorizontalMovement()
    {
        if (started)
        {
            speedX = 6.75f;

            //Normal Movement
            speedX += horizontalSpeed;
            

            //Sliding
            if (Input.GetKey(Key.S)) isSliding = true;
            if (Input.GetKeyUp(Key.S)) isSliding = false;

            if (isSliding) speedX += 3;

            //Animation for HorizontalMovement
            if (Mathf.Abs(speedX) > 0.1f)
            {
                if (isSliding) playerImage.SetCycle(9, 1);  //Sliding Animation
                else playerImage.SetCycle(0, 9);            //Running Animation
            }

            MoveUntilCollision(speedX, 0);
        }
    }

    void VerticalMovement()
    {
        verticalSpeed += 0.19f;

        if ((Input.GetKeyDown(Key.W)) && !isSliding)
        {
            if (numberOfJump > 0)
            {
                verticalSpeed = -8.5f;
                --numberOfJump;
            }
            else maxNumberOfJump = 1;
        }

        isGrounded = false;

        if (MoveUntilCollision(0, verticalSpeed) != null)
        {
            verticalSpeed = 0;
            isGrounded = true;
            numberOfJump = maxNumberOfJump;
        }
    }

    public void checkIfStarted()
    {
        if (Input.GetKeyDown(Key.W))
        {
            started = true;
            canceler = true;
        }
        else
        {
            started = false;
            playerImage.SetCycle(2, 1); //Idle Animation
        }
    }
    void OnCollision(GameObject objectsColliding)
    {
        //Collisions - Pickup
        if (objectsColliding is DoubleJump doubleJump)
        {
            maxNumberOfJump = 2;
            doubleJump.LateDestroy();
            Console.WriteLine("Player takes Double Jump Pickup");
        }

        if (objectsColliding is Coin coin)
        {
            if (coin.coinType == "gold") coins += 3;
            else if (coin.coinType == "silver") coins += 2;
            else if (coin.coinType == "bronze") coins += 1;

            coin.LateDestroy();
            Console.WriteLine("Player gets a coin: " + coin.coinType);
            Console.WriteLine("Player's coins: " + coins);
        }

        //Collisions - Trap
        if (objectsColliding is Spike)
        {
            if (lastTimeAttacked < Time.time)
            {
                //ReceivedDamage(enemy.Damage);
                int spikeDamage = 1;
                this._health -= spikeDamage;
                Console.WriteLine("Player hits Spikes, Player's Health: " + _health);
                lastTimeAttacked = Time.time + 1000;
                //Console.WriteLine("Received Damage: " + enemy.Damage);
            }
        }
    }


    Sound shootingSound = new Sound("Single_Shot.wav");
    void Shooting()
    {
        if (Input.GetKey(Key.SPACE))
        {
            int delta_height = 0;

            Bullet bullet = new Bullet("shoot.png", 6, 1, this, bulletSpeed, 0.08f, 0.08f);
            //bullet.SetOrigin(this.width - 00, this.height);
            
            game.soundManager.PlaySound(shootingSound, "level");
            /*if (Input.GetKey(Key.V)) bullet.SetXY(this.x - 50, this.y - 50); //TOP
            if (Input.GetKey(Key.B)) bullet.SetXY(this.x + 100, this.y + 100); //BOTTOM*/
            if (ArduinoInput.leverValue <= 300)
            {
                delta_height = -50;
            }
            else if (ArduinoInput.leverValue >= 800)
            {
                delta_height = 50;
            }


            /*            if (Input.GetKey(Key.V))
                        {
                            delta_height = -50;
                        }
                        if (Input.GetKey(Key.B))
                        {
                            delta_height = 50;
                        }*/

            //if (ArduinoInput.leverValue >= 400 && ArduinoInput.leverValue <= 600) bullet.SetXY(this.x, this.y);
            Console.WriteLine("leverValue= {0}", ArduinoInput.leverValue);
            
            bullet.SetXY(this.x - 10 , this.y  + delta_height - 50); 
            lastTimeShot = Time.time + 500;
            Console.WriteLine("Player shooting bullet {0}" , delta_height);

            //get an array of all Shooter objects with FindObjectsOfType<Shooter>()
            //find out the distance between the player and every shooter 
            parent.AddChild(bullet);
        }
    }

    void CheckHealth()
    {
        if (_health <= 3)
        {
            ((MyGame)game).LoadLevel("loseScreen");
        }
    }

    public void AddForce(float fX, float fY)
    {
        speedX += fX;
        y += fY;
    }
}
