using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMoving playerMoving;

    // Start is called before the first frame update
    private void Start()
    {
        playerMoving = GameObject.FindObjectOfType<PlayerMoving>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMoving.Die(); // Call the Die method on the PlayerMoving script
        }
    // Kill the player when they hit an obstacle
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
