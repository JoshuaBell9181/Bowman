using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{

    [SerializeField] public string playerName;
    [SerializeField] public Bow bow;
    int lives = 3;
    PolygonCollider2D myCollider;
    void Start()
    {
        myCollider = GetComponent<PolygonCollider2D>();
    }

    public int GetLives(){
        return lives;
    }

    void OnCollisionEnter2D(Collision2D other) {
        lives -= 1;
    }

    public int GetNumOfShots(){
        return bow.GetNumberOfShots();
    }
}
