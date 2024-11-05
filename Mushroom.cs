using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the behavior of a Mushroom object in the game.
public class Mushroom : MonoBehaviour
{
    // The speed at which the mushroom moves..
    [SerializeField] private float velocity = 1.0f;
    // The x-position threshold where the mushroom is consdered off-screen and should be destroyed.
    [SerializeField] private float MushroomOutOfScreen = -3.2f;

    // Start is called before the first frame update.
    void Start()
    {

    }

    // Update is called once per frame.
    void Update()
    {
        // Each frame, move the Mushroom to simulate the game's obstacle movement.
        Move();
    }

    // This method moves the mushroom to the left based on the 'velocity' and 'Time.deltaTime' for smooth movement.
    private void Move()
    {
        // Mushroom move from right to left.
        // Calculate the distance to move the mushroom in this frame.
        float distance = velocity * Time.deltaTime;
        // Move the mushroom's position left by the calculated distance.
        transform.position -= new Vector3(distance, 0.0f, 0.0f);

        // Mushroom out of screen.
        // Destroy Mushroom
        // if Mushroom out of -3.2, then destroy Mushroom.
        // Check if the Mushroom has moved past the designated out-of-screen position.
        // If yes, destroy the Mushroom to free up resources.
        // If the mushroom's x-position is less than or equal to 'MushroomOutOfScreen', destroy the mushroom.
        if (transform.position.x <= MushroomOutOfScreen)
        {
            // Destroys this Mushroom instance when it moves out of screen.
            Destroy(gameObject);
        }
    }
}