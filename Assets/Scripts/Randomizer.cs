using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    int [] _randomDistance = { 
        0, 
        30, 
        40,
        50 
        };
    Shot[] shots;

    void Start()
    {
        int index = Random.Range(0,_randomDistance.Length);
        float xOffset = _randomDistance[index] / 2;
        P1.transform.position -= new Vector3(xOffset,0,0);
        P2.transform.position += new Vector3(xOffset,0,0);

        // We will create 5 shots for each distance only one will actuallyHit the player (1/5 probability)
        // Distance = 0
        switch (_randomDistance[index]){
            case 0:
                shots = new Shot[] {
                    new Shot(1500,-4,true),
                    new Shot(1500,-9, false),
                    new Shot(800,-23.01f, false),
                    new Shot(1104,-13.2f,false),
                    new Shot(834,-55,false)
                };
                break;
            case 30:
                shots = new Shot[] {
                    new Shot(975,-45f,true),
                    new Shot(1500,-17.9f, false),
                    new Shot(1200,-12f, false),
                    new Shot(900,-22.2f,false),
                    new Shot(834,-55,false)
                };
                break;
            case 40:
                shots = new Shot[] {
                    new Shot(1500,-16,true),
                    new Shot(1200,-34, false),
                    new Shot(800,-18.01f, false),
                    new Shot(923,-46f,false),
                    new Shot(966,-24,false)
                };
                break;
            case 50:
                shots = new Shot[] {
                    new Shot(1500,-18,true),
                    new Shot(1500,-22, false),
                    new Shot(1200,-28f, false),
                    new Shot(1500,-12.3f,false),
                    new Shot(1000,-37,false)
                };
                break;
        }
    }

    public Shot Getshot(){
        int index = Random.Range(0,shots.Length);
        return shots[index];
    }
    
}
