using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot
{
    float power;
    float angle;
    bool actuallyHits;

    public Shot(float power, float angle, bool actuallyHits){
        this.power = power;
        this.angle = angle;
        this.actuallyHits = actuallyHits;
    }

    public float GetPower(){
        return power;
    }

    public float GetAngle(){
        return angle;
    }
}
