using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
class AimIndicator : Sprite
{
    //private float currentRotation = 0;
    private float upperLimit = 30;
    private float lowerLimit = -30;
    private float leverMaxValue = 1024;
    private float leverMinValue = 0;



    public AimIndicator() : base("aimingtriangle.png", addCollider : false)
    {
        y = -this.height / 2;
        //scale = 2; 
        
    }

    public float GetAimingDirection()
    {
        return rotation;
    }


    public float MapLeverValue(float inputValue)
    {
        float outPutValue = inputValue / (leverMaxValue - leverMinValue) * (-lowerLimit + upperLimit) - 30f;
        if (outPutValue > upperLimit) outPutValue = upperLimit;
        else if (outPutValue < lowerLimit) outPutValue = lowerLimit;
        return outPutValue;
    }
    public void SetAimingDirection(float direction)
    {
        rotation = direction;
    }


}
