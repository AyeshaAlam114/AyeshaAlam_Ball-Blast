using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHealth : MonoBehaviour
{
    public int health;
    Ball ballRef;

    private void Start()
    {
        ballRef = this.gameObject.GetComponent<Ball>();                     //get reference of Ball
    }
    public void DecreaseHealth()
    {
        health--;                                                            //decrement in ball health
        if (health == 0)                                                     //if ball's health ended
            ballRef.DestroyBall();                                           //destroy ball call
    }

}
