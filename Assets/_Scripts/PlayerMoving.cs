
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMoving : MonoBehaviour
{
    bool alive = true; // Player is alive

    public float speed = 5f; // Speed of the player movement
    [SerializeField] Rigidbody rb;

    public float horizontalMultiplier = 2f; // Multiplier for horizontal movement speed

    [SerializeField] float horizontalInput;

    public float speedIncreasePerPoint = 0.1f; // Speed increase per point collected

    [SerializeField] float jumpForce = 400f; // Jump force

    [SerializeField] LayerMask groundMask; // Layer mask for ground detection
    
    private void FixedUpdate()
    {
        if (!alive) return; // If the player is not alive, do not move

        Vector3 forewardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove + forewardMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die(); // Call the Die method if the player falls below a certain height
        }
        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Check for jump input
        {
            Jump(); // Call the Jump method
        }
    }

    public void Die()
    {
        alive = false; // Set alive to false when the player dies
                       // Reset the player position to the start position
        Invoke("Restart", 2f); // Restart the game after a delay of 2 seconds
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void Jump()
    {
        // Check whether we are on the ground
        float height = GetComponent<Collider>().bounds.extents.y; // Get the height of the player
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask); // Check if there is ground below the player
                                                                                                              // If we are , jump
        rb.AddForce(Vector3.up * jumpForce); // Apply an upward force to the player
    }
}
