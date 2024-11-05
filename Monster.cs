using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the movement and behavior of a monster object in the game.
// The monster moves leftward, and is destroyed when it goes off-screen.
public class Monster : MonoBehaviour
{
    // Speed at which the monster moves.
    [SerializeField] private float velocity = 1.0f;
    // X position where the monster will be destroyed.
    [SerializeField] private float MonsterOutOfScreen = -3.2f;

    // Start() is called before the first frame update.
    void Start()
    {

    }

    // Update() is called once per frame.
    void Update()
    {
        Move();
    }

    // Moves the monster to the left based on the velocity. Destroys the monster when it reaches the specified off-screen position.
    private void Move()
    {
        // Calculate the distance to move based on velocity and frame time.
        float distance = velocity * Time.deltaTime;
        // Move the monster to the left by subtracting distance from its x position.
        transform.position -= new Vector3(distance, 0.0f, 0.0f);

        // Check if the monster has reached or passed the off-screen position.
        // If so, destroy the monster object to free up resources.
        if (transform.position.x <= MonsterOutOfScreen)
        {
            Destroy(gameObject);
        }
    }
}