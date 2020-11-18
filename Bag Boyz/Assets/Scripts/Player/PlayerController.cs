using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public float speed = 0.5f; //can adjust Player Speed in Unity inspector
    public float standardSpeed;
    public float interactionTimer = 1.0f; //Adjust player interaction speed
    public bool eightDirections = false; //can turn on and off eightDirections in Unity inspector
    public bool collectingItem = false;
    public bool canMove = true;

    private Vector2 movement;
    private bool facingLeft = true;


    private void Awake()
    {
        standardSpeed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Finds Animator Controller component attached to Player
        anim = this.GetComponent<Animator>();

        //Finds Rigidbody2D component attached to Player
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


        if (canMove)
        {
            if (!collectingItem)
            {
                //If eightDirections is turned off use 4 directional movement
                if (!eightDirections)
                {
                    //If the D key is pressed
                    if (Input.GetKey(KeyCode.D))
                    {
                        //Remove any excess animations
                        TurnOffAnimations();

                        //Player is facing right
                        facingLeft = false;

                        //Play Walking Right animation
                        anim.SetBool("MovingRight", true);

                        //Move Player towards the right direction by player speed
                        //transform.Translate(Vector2.right * speed * Time.deltaTime);

                        Move(1, 0);

                    }



                    //If the A key is pressed
                    else if (Input.GetKey(KeyCode.A))
                    {
                        //Remove any excess animations
                        TurnOffAnimations();

                        //Player is facing left
                        facingLeft = true;

                        //Play Walking Left animation
                        anim.SetBool("MovingLeft", true);


                        //Move Player towards the Left direction by player speed
                        //transform.Translate(Vector2.left * speed * Time.deltaTime);

                        Move(-1, 0);
                    }


                    //If the S key is pressed
                    else if (Input.GetKey(KeyCode.S))
                    {
                        //Remove any excess animations
                        TurnOffAnimations();

                        //Play left animation if player is facing left, else play right animation
                        if (facingLeft)
                        {
                            //Play Walking Left animation
                            anim.SetBool("MovingLeft", true);
                        }
                        else
                        {
                            //Play Walking right animation
                            anim.SetBool("MovingRight", true);
                        }

                        //Move Player towards the Down direction by player speed
                        //transform.Translate(Vector2.down * speed * Time.deltaTime);

                        Move(0, -1);
                    }


                    //If the W key is pressed
                    else if (Input.GetKey(KeyCode.W))
                    {
                        //Remove any excess animations
                        TurnOffAnimations();

                        //Play left animation if player is facing left, else play right animation
                        if (facingLeft)
                        {
                            //Play Walking Left animation
                            anim.SetBool("MovingLeft", true);
                        }
                        else
                        {
                            //Play Walking right animation
                            anim.SetBool("MovingRight", true);
                        }

                        //Move Player towards the Up direction by player speed
                        //transform.Translate(Vector2.up * speed * Time.deltaTime);

                        Move(0, 1);
                    }


                    //If none of the keys are being pressed
                    else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                    {
                        //Remove any excess animations
                        TurnOffAnimations();

                        //If the Player is facing left
                        if (facingLeft)
                        {
                            //Play Left Idle animation
                            anim.SetBool("IdleLeft", true);
                        }
                        else
                        {
                            //Play Right Idle animation
                            anim.SetBool("IdleRight", true);
                        }

                        Move(0, 0);
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
                    Move(movement.x, movement.y);

                    //transform.Translate(movement * speed * Time.deltaTime);
                }

            }
            
            else if (collectingItem)
            {
                if (facingLeft)
                {
                    TurnOffAnimations();
                    anim.SetBool("InteractLeft", true);
                }
                else
                {
                    TurnOffAnimations();
                    anim.SetBool("InteractRight", true);
                }
            }
        }
        
        

    }

    public void Move(float velX, float velY)
    {
        rb.velocity = new Vector2(velX * speed, velY * speed);
    }


    public void npcInteract()
    {
        TurnOffAnimations();

        if (facingLeft)
        {
            anim.SetBool("IdleLeft", true);
        }
        else
        {
            anim.SetBool("IdleRight", true);
        }
    }


    public void TurnOffAnimations()
    {
        //Stop all animations from being active
        anim.SetBool("IdleLeft", false);
        anim.SetBool("IdleRight", false);
        anim.SetBool("MovingLeft", false);
        anim.SetBool("MovingRight", false);
        anim.SetBool("InteractLeft", false);
        anim.SetBool("InteractRight", false);
    }

}


