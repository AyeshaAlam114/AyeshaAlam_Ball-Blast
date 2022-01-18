using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxRange;
    public float minRange;

    public SpawnManager spawnRef;
    public GameManager refGM;

    float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        if (refGM.gameOver == false)                                                                            //check if game is in over or run state
        {
            horizontalInput = Input.GetAxis("Horizontal");                                                      //get horizontal input value from user
            if (horizontalInput != 0)                                                                           // check if user insert some input
                transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);                  //move player on x-axis
            if (transform.position.x > maxRange)                                                                //check if player position exceed max limit or not
                transform.position = new Vector3(maxRange, transform.position.y, transform.position.z);         //set its position to max limit
            if (transform.position.x < minRange)                                                                //check if player position exceed min limit or not
                transform.position = new Vector3(minRange, transform.position.y, transform.position.z);         //set its position to min limit
            if (Input.GetKeyDown(KeyCode.Space))                                                                //check if user presses space key
                spawnRef.FireBullet();                                                                          //call to fire
        }
    }
}
