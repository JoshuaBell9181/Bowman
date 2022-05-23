using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit = false;
    [SerializeField] float power = 0;
    [SerializeField] float angle = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit == false){
            trackMovement();
        }
    }

    void trackMovement(){
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }

    void OnCollisionEnter2D(Collision2D collider){
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

    public bool GetHasHit(){
        return hasHit;
    }

    public void SetAngle(float value){
        angle = value;
    }

    public void SetPower(float value){
        power = value;
    }
}
