using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloor : MonoBehaviour
{

    //Reference to the Player
    public PlayerController player;


    //True when the player is sticky
    public bool playerSticky = false;


    //Modifies player speed when sticky
    public float stickySpeed = 0.5f;



    // Update is called once per frame
    void Update()
    {
        if (playerSticky)
        {
            player.speed = player.standardSpeed * stickySpeed;
        }
        else
        {
            player.speed = player.standardSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerSticky = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSticky = false;
        }
        
    }
}
