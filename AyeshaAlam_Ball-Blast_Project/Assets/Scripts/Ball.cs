using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool ballInBoundary;
    GameManager refGM;

    // Start is called before the first frame update
    void Start()
    {
        ballInBoundary = true;                                                                          //set true if ball is in boundary
        refGM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();            //get Game manager refrence
    }

    // Update is called once per frame
    void Update()
    {
        CheckInBoundary();                                                                              //call to check boundary        
    }

    public void DestroyBall()
    {
        if (this.ballInBoundary)                                                                        //check if ball is in boundary or not
        {
            refGM.AddScore();                                                                           //Add score (determines that it is destructed by player)
            Invoke(nameof(ApplyDestruction), 1f);                                                       //call to destroy
        }
        else
            ApplyDestruction();                                                                         //call to destroy
    }

    void ApplyDestruction()
    {
        Destroy(gameObject);                                                                            //destroy this balls
    }
    void CheckInBoundary()
    {
        if (transform.position.y < 0)                                                                   //check if ball is fall down by plane or not
        {
            ballInBoundary = false;                                                                     //ball in boundary false
            ApplyDestruction();                                                                         //call to destroy
        }
    }
}
