using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{

    // Reference to the Player
    private PlayerController player;

    // True when the Player is Sliding
    private bool playerSliding = false;

    private float slideSpeed = 2.0f;

    private float maxSlideTimer = 2.0f;
    private float slideTimer = 2.0f;

    private float pad = 5.0f;

    // Stores the last movement key that was pressed
    KeyCode lastKeyPressed;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Checks the last movement key pressed (W, S, A or D)
        // Stores that key in the lastKeyPressed variable
        if (playerSliding == false)
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

            if (slideTimer > 0)
            {
                slideTimer -= Time.deltaTime;
            }
            else
            {
                ResetPlayerPosition();
                slideTimer = maxSlideTimer;
            }
            

            // Checks which movement key was last pressed
            // Forces the player to move in that direction



            // Left
            if (lastKeyPressed == KeyCode.A)
            {
                player.Move(-1, 0);
                //player.transform.Translate(Vector2.left * player.speed * Time.deltaTime);
            }


            // Right
            else if (lastKeyPressed == KeyCode.D)
            {
                player.Move(1, 0);
                //player.transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }


           
            else if (lastKeyPressed == KeyCode.W)
            {
                //player.Move(0, slideSpeed);
                //player.transform.Translate(Vector2.up * player.speed * Time.deltaTime);

            }
            
            else if (lastKeyPressed == KeyCode.S)
            {
                //player.Move(0, -slideSpeed);
                //player.transform.Translate(Vector2.down * player.speed * Time.deltaTime);
            }
            
        }

    }

    
    void ResetPlayerPosition()
    {
        if (lastKeyPressed == KeyCode.W)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == KeyCode.S)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == KeyCode.A)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == KeyCode.D)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSliding = true;

            player.SetPlayerSpeed(slideSpeed);

            player.canMove = false;
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSliding = false;

            player.SetPlayerSpeed(1 / slideSpeed);

            player.canMove = true;
        }
    }

}
