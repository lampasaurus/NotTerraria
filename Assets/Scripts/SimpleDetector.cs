using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDetector : MonoBehaviour {
    public bool collidedBlock;
    public bool collided;
    public bool colliding;

    private void Start()
    {
        collided = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;
        colliding = true;
        if (collision.tag == "Block")
        {
            collidedBlock = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }
}
