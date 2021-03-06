using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxBoundary;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxBoundary)                     //check if bullet reaches the upper boundary 
            Destroy(gameObject);                                    //destroy bullet when it cross boundary
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))                           //check if the hitted object is obstacle or not
        {
            other.GetComponent<BallHealth>().DecreaseHealth();      //if it is obstacle then decrease obstacle health
            Destroy(gameObject);                                    //after decreasing obstacle's health destroy bullet
        }
    }

}
