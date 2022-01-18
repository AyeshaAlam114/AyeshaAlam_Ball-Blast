using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager refGM;
    public float maxPlayerHealth;
    public float playerHealth;


    private void Start()
    {
        playerHealth = maxPlayerHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))                            //check if the hitted object is obstacle or not
            DecreaseHealth();                                                       //if it is obstacle then decrease player's health
    }
    public void DecreaseHealth()
    {
        playerHealth--;                                                             //decrement in player health
        if (playerHealth == 0)                                                      //if player's health ended
            refGM.GameOver();                                                       //game is over
    }

}
