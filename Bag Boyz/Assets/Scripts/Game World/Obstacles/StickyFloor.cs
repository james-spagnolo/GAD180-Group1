using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloor : MonoBehaviour
{

    //Reference to the Player
    private PlayerController player;


    //True when the player is sticky
    private bool playerSticky = false;


    //Modifies player speed when sticky
    private float stickySpeed;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        stickySpeed = player.GetDefaultSpeed() / 2;
    }



    // Update is called once per frame
    void Update()
    {
        
            if (playerSticky)
            {
                player.SetPlayerSpeed(stickySpeed);
                playerSticky = false;
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

            player.SetPlayerSpeed(player.GetDefaultSpeed());
        }
        
    }
}
