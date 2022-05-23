using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bow : MonoBehaviour
{
    const float MAX_POWER = 1500;
    bool isShooting = false;
    bool isComputerShooting = false;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject ArrowOffest;
    [SerializeField] GameObject ActionCamera;
    [SerializeField] GameObject computer;
    [SerializeField] Sprite[] images;
    [SerializeField] float original_x = 0;
    [SerializeField] float original_y = 0;
    [SerializeField] float angle = 0;
    [SerializeField] float power = 0;

    [SerializeField] bool isHuman = true;

    SpriteRenderer bow;

    int numOfShots = 0;

    void Start(){
        bow = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(isHuman){
            ActLikeHuman();
        } else {
            if(isComputerShooting){
                
                ActLikeComputer();
            }
        }
    }

    void ActLikeComputer(){
        // Take the shot
        isShooting = false; 
        isComputerShooting = false;   

        Shot shot = computer.GetComponent<Randomizer>().Getshot();
        power = shot.GetPower();
        angle = shot.GetAngle();
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Shoot();
    }

    void ActLikeHuman(){
        if (Input.GetMouseButtonDown(0)) {
            isShooting = true;
        }
        if (Input.GetMouseButtonUp(0)){
            isShooting = false;
            Shoot();
            UpdateImage();
        }

        if (!isShooting) {
            BowDirection();
        } else {
            Power();
            UpdateImage();
        }
    }

    void BowDirection(){
            //rotation
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
    
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = Mathf.Sign(transform.localScale.x) * (mousePos.x - objectPos.x);
            mousePos.y = Mathf.Sign(transform.localScale.x) * (mousePos.y - objectPos.y);
            original_x = Mathf.Sign(transform.localScale.x) * mousePos.x;
            original_y = Mathf.Sign(transform.localScale.x) * mousePos.y;
    
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot(){
        GameObject ArrowIns = Instantiate(Arrow, ArrowOffest.transform.position ,transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(Mathf.Sign(transform.localScale.x) * transform.right * power);
        ActionCamera.GetComponentInChildren<CameraManager>().FollowArrow(ArrowIns.GetComponent<Arrow>());

        power = 0;
        numOfShots += 1;
    }

    /*
    * Description: Determine the power based on drag position
    * Returns: integer between 0 and 100
    */
    void Power() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        power = (float) Math.Floor(Math.Abs(original_x - mousePos.x));
        
        if(power > 250){
            power = 250;
        }

        power *= 6;
    }

    void UpdateImage(){
        bow.sprite = images[(int)(power/100) % images.Length]; 
    }

    public int GetNumberOfShots(){
        return numOfShots;
    }

    public void SetIsComputerShooting(bool value){
        isComputerShooting = value;
    }
}
