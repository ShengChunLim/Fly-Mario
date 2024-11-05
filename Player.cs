using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the player's behavior, including movement, collisions, and audio feedback.
public class Player : MonoBehaviour
{
    // Variables for player movement, references to other game components, and audio clips
    public float flyVelocity;
    public GameManager gameManager;
    public Rigidbody2D rigidBody2D;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip wingClip;
    public AudioClip hitClip;
    public AudioClip dieClip;
    public AudioClip pointClip;
    public AudioClip superstarClip;
    public AudioClip killClip;
    [SerializeField]
    private bool isInvincible = false;
    private float endInvincibleTime = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make the player "fly" when the spacebar is pressed, and play the wing sound.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody2D.velocity = new Vector2(0.0f, flyVelocity);
            audioSource.PlayOneShot(wingClip);
        }

        // Check if the invincibility period has ended.
        if (isInvincible == true)
        {
            if (Time.time >= endInvincibleTime)
            {
                Debug.Log("End Invincible Time: ");
                isInvincible = false;
                animator.SetBool("IsInviciable", false);
            }
        }
        
    }

    // Called when the player collides with another object with a 2D collider
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Sets "OnGround" animation state if the player collides with a "Base" object.
        if (collision.gameObject.tag == "Base")
        {
            animator.SetBool("OnGround", true);
        }
    }

    // Called when the player exits collision with another object
    public void OnCollisionExit2D(Collision2D collision)
    {
        // Resets "OnGround" animation state when player leaves a "Base" object.
        if (collision.gameObject.tag == "Base")
        {
            animator.SetBool("OnGround", false);
        }
    }

    // Called when the player enters a trigger collider
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // Handles collision with "Mushroom" objects (game over if not invincible).
        if (collider.tag == "Mushroom")
        {

            if (isInvincible == false)
            {
                audioSource.PlayOneShot(hitClip);
                audioSource.PlayOneShot(dieClip);
                Debug.Log("Game Over");
                gameManager.GameOver();
                collider.enabled = false;
            }
            else
            {
                Destroy(collider.gameObject);
                audioSource.PlayOneShot(killClip);
                gameManager.AddScore();
            }

        }

        // Handles collision with "Monster" objects (decreases score if not invincible).
        if (collider.tag == "Monster")
        {
            if (isInvincible == false)
            {
                Debug.Log("Decrease Score");
                gameManager.DecreaseScore();
                collider.enabled = false;
            }
            else
            {
                Destroy(collider.gameObject);
                audioSource.PlayOneShot(killClip);
                gameManager.AddScore();
            }
            
        }

        // Handles collision with "SuperStar" objects (grants invincibility for 5 seconds).
        if (collider.tag == "SuperStar")
         {
            Debug.Log("Start Invincible: ");
            gameManager.AddScore();
            isInvincible = true;
            animator.SetBool("IsInviciable", true);
            // Set invincibility duration to 5 seconds
            endInvincibleTime = Time.time + 5f;
            collider.enabled = true;
            Destroy(collider.gameObject);
            audioSource.PlayOneShot(superstarClip);
        }

        // Handles collision with "Coin" objects (adds score and plays point sound). 
        if (collider.tag == "Coin")
        {
            Debug.Log("Mario collided with " + collider.tag);
            gameManager.AddScore();
            audioSource.PlayOneShot(pointClip);
            collider.enabled = false;
            Destroy(collider.gameObject);
        }

    }
}