using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{

    // Reference to the Player
    public PlayerController player;

    // True when the Player is Sliding
    public bool playerSliding = false;

    public int slideSpeed = 2;

    // Stores the last movement key that was pressed
    KeyCode lastKeyPressed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Checks the last movement key pressed (W, S, A or D)
        // Stores that key in the lastKeyPressed variable
        if(playerSliding == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lastKeyPressed = KeyCode.W;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                lastKeyPressed = KeyCode.S;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                lastKeyPressed = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                lastKeyPressed = KeyCode.D;
            }
        }



        // Checks if the Player is sliding
        // The main wet floor sliding movement logic goes here
        if (playerSliding)
        {

            // Checks which movement key was last pressed
            // Forces the player to move in that direction
            if (lastKeyPressed == KeyCode.W)
            {
                player.Move(0, slideSpeed);
                player.transform.Translate(Vector2.up * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.A)
            {
                player.Move(-slideSpeed, 0);
                player.transform.Translate(Vector2.left * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.S)
            {
                player.Move(0, -slideSpeed);
                player.transform.Translate(Vector2.down * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.D)
            {
                player.Move(slideSpeed, 0);
                player.transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }
        }


        /*
        //work around until rigidbody movement is implemented
        if (player.gameObject.GetComponent<Renderer>().bounds.Intersects(gameObject.GetComponent<Renderer>().bounds))
        {
            playerSliding = true;
        }
        else
        {
            playerSliding = false;
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSliding = true;
            player.canMove = false;
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSliding = false;
            player.canMove = true;
        }
    }

}
