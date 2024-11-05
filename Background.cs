using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the movement of a background object to create a scrolling effect.
// When the object reaches a specified position, it resets to the starting position.
public class Background : MonoBehaviour
{
    // Speed at which the background moves.
    [SerializeField]private float velocity = 1.0f;
    // X position at which the background resets to its starting position.
    [SerializeField]private float returnPosition = -2.7f;

    // Start() is called before the first frame update.
    void Start()
    {

    }

    // Called once per frame. Updates the background's position.
    void Update()
    {
        Move();
    }

    // Moves the background to the left, creating a scrolling effect.
    private void Move()
    {

        // Calculate the distance to move based on velocity and frame time.
        float distance = velocity * Time.deltaTime;
        // Move the background to the left by subtracting distance from its x position.
        transform.position -= new Vector3(distance, 0.0f, 0.0f);

        // Check if the background has reached or passed the return position.
        // If so, reset it to the starting position (0,0,0).
        if (transform.position.x <= returnPosition)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}