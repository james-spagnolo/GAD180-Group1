using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{

    // Reference to the Player
    private PlayerController player;

    // True when the Player is Sliding
    private bool playerSliding = false;

    private float slideSpeed;

    private float maxSlideTimer = 2.0f;
    private float slideTimer = 2.0f;

    private float pad = 5.0f;

    private KeyCode up;
    private KeyCode down;
    private KeyCode left;
    private KeyCode right;


    // Stores the last movement key that was pressed
    KeyCode lastKeyPressed;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        slideSpeed = player.GetDefaultSpeed() * 2.5f;

        up = ControlsManager.CM.up;
        down = ControlsManager.CM.down;
        left = ControlsManager.CM.left;
        right = ControlsManager.CM.right;
    }

    // Update is called once per frame
    void Update()
    {

        // Checks the last movement key pressed (W, S, A or D)
        // Stores that key in the lastKeyPressed variable
        if (playerSliding == false)
        {
            
            if (Input.GetKeyDown(up))
            {
                lastKeyPressed = up;
            }
            else if (Input.GetKeyDown(down))
            {
                lastKeyPressed = down;
            }
            else if (Input.GetKeyDown(left))
            {
                lastKeyPressed = left;
            }
            else if (Input.GetKeyDown(right))
            {
                lastKeyPressed = right;
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
            if (lastKeyPressed == left)
            {
                player.Move(-1, 0);
                //player.transform.Translate(Vector2.left * player.speed * Time.deltaTime);
            }


            // Right
            else if (lastKeyPressed == right)
            {
                player.Move(1, 0);
                //player.transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }


           
            else if (lastKeyPressed == up)
            {
                //player.Move(0, slideSpeed);
                //player.transform.Translate(Vector2.up * player.speed * Time.deltaTime);

            }
            
            else if (lastKeyPressed == down)
            {
                //player.Move(0, -slideSpeed);
                //player.transform.Translate(Vector2.down * player.speed * Time.deltaTime);
            }
            
        }

    }

    
    void ResetPlayerPosition()
    {
        if (lastKeyPressed == up)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == down)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == left)
        {
            player.transform.position = new Vector2(this.transform.position.x + pad, this.transform.position.y + pad);
        }
        else if (lastKeyPressed == right)
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

            player.SetPlayerSpeed(player.GetDefaultSpeed());

            player.canMove = true;
        }
    }

}
