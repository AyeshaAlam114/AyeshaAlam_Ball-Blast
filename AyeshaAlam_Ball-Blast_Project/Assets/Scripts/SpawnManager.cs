using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Transform[] ballSpawnPosition;
    public Color[] ballColor;
    public GameObject ballPrefab;

    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;

    public float startDelay;
    public float ballForce;
    public float bulletForce;

    public int spawnNumber;
    public int ballColorNumber;
    public int ballMinScale;
    public int ballMaxScale;

    public GameManager refGM;

    GameObject ball;
    Rigidbody bullet;
    int ballScale;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstacleSpawner", startDelay, Random.Range(0.1f, 3));                                                          //repeatedly spwning of obstacles
    }


    void ObstacleSpawner()
    {
        if (refGM.gameOver == false)                                                                                                    //check if game is in run or over state
        {
            spawnNumber = Random.Range(0, ballSpawnPosition.Length);                                                                    //select random position from position's array
            ballColorNumber = Random.Range(0, ballColor.Length);                                                                        //select random color from ball color's array
            ball = Instantiate(ballPrefab, ballSpawnPosition[spawnNumber].position, Quaternion.identity);                               //spawn ball and save it's rigidbody component in ball

            ball.GetComponent<Renderer>().material.color = ballColor[ballColorNumber];                                                  //give ball's material a random color

            ballScale = Random.Range(ballMinScale, ballMaxScale);                                                                       //get random scale value
            ball.transform.localScale = new Vector3(ballScale, ballScale, ballScale);                                                   //set ball's scale value
            ball.GetComponent<Ball>().ballInBoundary = true;                                                                            //set ballInBoundary to true

            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            if (spawnNumber < (int)ballSpawnPosition.Length / 2)                                                                        //check if spawn number is less then its half or not
                ballRb.AddForce(Vector3.right * Time.deltaTime * ballForce, ForceMode.Acceleration);                                    // apply force in right
            else
                ballRb.AddForce(Vector3.left * Time.deltaTime * ballForce, ForceMode.Acceleration);                                     // apply force in left
        }
    }

    public void FireBullet()
    {
        if (refGM.gameOver == false)                                                                                                    //check if game is in run or over state
        {
            bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity).GetComponent<Rigidbody>();            //spawn bullet and save it's rigidbody component in bullet
            bullet.AddForce(Vector3.up * Time.deltaTime * bulletForce * refGM.gravityModifier * 2, ForceMode.Impulse);                  // apply force in up direction
        }

    }
}
