using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public float speed = 0.5f; //can adjust Player Speed in Unity inspector
    public bool eightDirections = false; //can turn on and off eightDirections in Unity inspector
    private Vector2 movement;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Toggle 4D / 8D Movement by Pressing 1
        if (Input.GetKey("1"))
        {
            print("Toggled 4D/8D");
            eightDirections = !eightDirections;
        }

        //If eightDirections is turned off use 4 directional movement
        if (!eightDirections)
        {

            if (Input.GetKey(KeyCode.D))
            {
                TurnOffAnimations();

                //Play Right animation
                anim.SetBool("MovingRight", true);

                //Move Player towards the right direction by player speed
                transform.Translate(Vector2.right * speed * Time.deltaTime);

            }

            else if (Input.GetKey(KeyCode.A))
            {
                TurnOffAnimations();

                //Play Left animation
                anim.SetBool("MovingLeft", true);

                //Move Player towards the Left direction by player speed
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                TurnOffAnimations();

                //Play Down animation
                anim.SetBool("MovingDown", true);

                //Move Player towards the Down direction by player speed
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.W))
            {
                TurnOffAnimations();

                //Play Up animation
                anim.SetBool("MovingUp", true);

                //Move Player towards the Up direction by player speed
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                TurnOffAnimations();

                //Play Idle Animation
                anim.SetBool("NotMoving", true);
            }
        }



        //If eightDirections is on use 8 directional movement
        else if (eightDirections)
        {

            //Get Horizontal Player Input (Left to Right)
            float inputX = Input.GetAxisRaw("Horizontal");

            //Get Vertical Player Input (Top to Bottom)
            float inputY = Input.GetAxisRaw("Vertical");

            //Create movement Vector with position equal to player input
            movement = new Vector2(inputX, inputY);

            //Checks if the Player is moving diagonally
            if (inputX != 0 && inputY != 0)
            {
                //If the player is moving towards the top left
                if (movement.y == 1 && movement.x == -1)
                {
                    //Play top left animation
                }

                //If the player is moving towards the top right
                if (movement.y == 1 && movement.x == 1)
                {
                    //Play top right animation
                }

                //If the player is moving towards the bottom left
                if (movement.y == -1 && movement.x == -1)
                {
                    //Play bottom left animation
                }

                //If the player is moving towards the bottom right
                if (movement.y == -1 && movement.x == 1)
                {
                    //Play bottom right animation
                }
            }

            else
            {

                //If the player is moving left
                if (movement.x == -1)
                {
                    TurnOffAnimations();

                    //Play left animation
                    anim.SetBool("MovingLeft", true);
                }

                //If the player is moving right
                if (movement.x == 1)
                {
                    TurnOffAnimations();

                    //Play right animation
                    anim.SetBool("MovingRight", true);
                }

                //If the player is moving up
                if (movement.y == 1)
                {
                    TurnOffAnimations();

                    //Play up animation
                    anim.SetBool("MovingUp", true);
                }

                //If the player is moving down
                if (movement.y == -1)
                {
                    TurnOffAnimations();

                    //Play down animation
                    anim.SetBool("MovingDown", true);
                }
            }

            //If the player is NOT moving
            if (movement.x == 0 && movement.y == 0)
            {
                TurnOffAnimations();

                //Play Idle Animation
                anim.SetBool("NotMoving", true);
            }

            //Move the player in the direction of input by 'speed' units per second.
            Move();

            //transform.Translate(movement * speed * Time.deltaTime);
        }


    }

    private void Move()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    
    void TurnOffAnimations()
    {
        //Stop all animations from being active
        anim.SetBool("NotMoving", false);
        anim.SetBool("MovingLeft", false);
        anim.SetBool("MovingRight", false);
        anim.SetBool("MovingUp", false);
        anim.SetBool("MovingDown", false);
    }

}
