/**
Created by: Kyunghoon Han
Date Created: 1/31/22

Last Edited by: N/A
Last Edited: 1/31/22

Description: Control the Movement of AppleTree
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Variables
    [Header("SET IN INSPECTOR")]
    public float speed = 1f; //tree speed
    public float leftAndRightEdge = 10f; // Distance where tree turns around
    public GameObject applePrefab; //prefab for instantiating apples
    public float secondsBetweenAppleDrops = 1f; // Time between apple drops
    public float chanceToChangeDirections = 0.02f; //chance that the tree changes direction (2%)
    public static float bottomY = -20f; // Apple is destroyed at this point
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f); // Dropping apples every second
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);      // c
        apple.transform.position = transform.position;                  // d
        Invoke("DropApple", secondsBetweenAppleDrops);                // e
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) // This if statement destroys the apple at a certain point
        {
            Destroy(this.gameObject);
        }

        //Basic Movement
        Vector3 pos = transform.position; // records the current position
        pos.x += speed * Time.deltaTime; // adds speed to x position
        transform.position = pos; // apply the position value
        
        //Change Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // set speed to positive
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // set speed to negative

        } // end Change Direction
    } // end update

    //Fixedupdate is called on fixed intervals (50 times per second)
    private void FixedUpdate()
    {
       // Test change of direction change
       if(Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change directions
        }
    } // end FixedUpdate()

}
