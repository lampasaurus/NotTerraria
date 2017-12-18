using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    public float speedMax;
    public float acceleration;
    public float jumpPower;
    public float friction;
    public GameObject footTrigger;



    float speed;
    SimpleDetector footScript;
    Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        footScript = footTrigger.GetComponent<SimpleDetector>();
	}
    

    // Update is called once per frame
    void FixedUpdate () {
        
        //Jumping
        if (Input.GetKeyDown("space"))
        {
            if (footScript.collidedBlock)
            {
                addForce(jumpPower, "up");
            }
            footScript.collidedBlock = false;
        }
        //Moving left
        if (Input.GetKey("a"))
        {
            addForce(acceleration, "left");
        }
        //Moving Right
        if (Input.GetKey("d"))
        {
            addForce(acceleration, "right");
        }

        //Decelleration/friction
        if ((((speed - friction) < 0 ) && speed > 0) ||
                    ((speed + friction) > 0 && speed < 0)){
            speed = 0;
        }
        else if(speed > 0)
        {
            speed -= friction;

        }
        else if(speed < 0)
        {
            speed += friction;
        }
        //Actually move the player
        transform.Translate(speed, 0, 0);
	}

    //Generic function for changing player speed
    private void addForce(float force, string dir)
    {
        if(dir == "left")
        {
            //Rapidly slow down if moving right
            if (speed > 0)
            {
                speed = (speed / 1.2f);
            }
            speed -= (force + friction);
            if (speed < -speedMax)
            {
                speed = -speedMax;
            }
        }
        else if (dir == "right")
        {
            //rapidly slow down if moving left
            if (speed < 0)
            {
                speed = (speed / 1.2f);
            }
            speed += force + friction;
            if (speed > speedMax)
            {
                speed = speedMax;
            }
        }
        else if (dir == "up")
        {

            rigidbody2d.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
        else if (dir == "down")
        {

            rigidbody2d.AddForce(-transform.up * force, ForceMode2D.Impulse);
        }
    }
    
}
