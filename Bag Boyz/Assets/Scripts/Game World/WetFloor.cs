using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetFloor : MonoBehaviour
{

    public PlayerController player;

    public bool playerSliding = false;

    KeyCode lastKeyPressed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            lastKeyPressed = KeyCode.W;
        }
        else if (Input.GetKeyDown("s"))
        {
            lastKeyPressed = KeyCode.S;
        }
        else if (Input.GetKeyDown("a"))
        {
            lastKeyPressed = KeyCode.A;
        }
        else if (Input.GetKeyDown("d"))
        {
            lastKeyPressed = KeyCode.D;
        }


        if (playerSliding == true)
        {

            if (lastKeyPressed == KeyCode.W)
            {
                player.transform.Translate(Vector2.up * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.A)
            {
                player.transform.Translate(Vector2.left * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.S)
            {
                player.transform.Translate(Vector2.down * player.speed * Time.deltaTime);
            }
            if (lastKeyPressed == KeyCode.D)
            {
                player.transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }
        }


        //work around until rigidbody movement is implemented
        if (player.gameObject.GetComponent<Renderer>().bounds.Intersects(gameObject.GetComponent<Renderer>().bounds))
        {
            playerSliding = true;
        }
        else
        {
            playerSliding = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.tag == "Player")
        {
            playerSliding = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerSliding = false;
        }
    }

}
